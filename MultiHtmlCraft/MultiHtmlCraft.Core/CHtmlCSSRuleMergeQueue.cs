using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MultiHtmlCraft.Interfaces;

namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlCSSRuleMergeQueue : System.Collections.ArrayList, System.IDisposable
    {
        private Task ___QueueTask;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private readonly object ___AddToQueueLockingObject = new object();
        public bool Disposing;
        public bool IsAllCSSComplete;
        public bool ___needsExitFunctionIfQueueZero;
        private int MergedCount;
        private int EnqueuedCount;
        public CHtmlDocument ___parentDocument;
        private System.WeakReference ___documentReference;
        public string ShortName = null;
        private const int MAX_WAIT = 5000;
        private CHtmlCSSRuleGroundKeyNonGenericComparer _GroundStyleSheetNonGenericSorter;
        private bool IsMergeFunctionEntered;
        private uint ___MeargedOrRemovedStyleCount;
        private uint ___StyleLongWaitOneCount;
        private uint ___StyleShortWaitOneCount;
        private readonly object ___MergeLockingObject = new object();
        internal bool __IsMergeQueueCompleted = false;

        // イベントの定義
        public event EventHandler MergeCompleted;

        public CHtmlCSSRuleMergeQueue()
        {
            _GroundStyleSheetNonGenericSorter = new CHtmlCSSRuleGroundKeyNonGenericComparer();
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }

        ~CHtmlCSSRuleMergeQueue()
        {
            this.Disposing = true;
            this.CleanUp();
        }

        private void CleanUp()
        {
            try
            {
                if (_cancellationTokenSource != null)
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource.Dispose();
                }
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            this.Disposing = true;
            this.CleanUp();
        }

        private int ___StyleStatus = -1;
        public void AddRange(CHtmlCSSRule[] value)
        {
            if (value == null)
            {
                return;
            }
            if (value.Length == 0)
            {
                return;
            }
            if (System.Threading.Monitor.TryEnter(this.___AddToQueueLockingObject, MAX_WAIT))
            {
                try
                {
                    base.AddRange(value);
                    System.Threading.Interlocked.Add(ref this.EnqueuedCount, value.Length);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("StyleQueue AddRange Exception", ex);
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(this.___AddToQueueLockingObject);
                }
            }
            else
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("Uhhh. CHtmlCSSRuleMergeQueue failed to obtain lock.");
                }
            }
            if (this.IsAllCSSComplete == true)
            {
                if (this.IsMergeFunctionEntered == false)
                {
                    if (___StyleStatus == 0)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
                        {
                            ___StyleStatus++;
                            commonLog.LogEntry("Style will be must be mearged as JIT afterword.");
                        }
                    }
                    if (!___needsExitFunctionIfQueueZero)
                    {
                        ___needsExitFunctionIfQueueZero = true;
                    }
                    this.PerformStyleGroudMeargeToGroundList(_cancellationToken);
                }
            }
            return;
        }

        public void Add(CHtmlCSSRule value)
        {
#if DEBUG
            if (string.IsNullOrEmpty(value.___baseUrl) == true)
            {
                commonLog.LogEntry("CHtmlCSSStyleSheet Add Style does not have baseURL. but cont : {0}...", value.___SelectorID);
            }
#endif
            if (System.Threading.Monitor.TryEnter(this.___AddToQueueLockingObject, MAX_WAIT))
            {
                try
                {
                    base.Add(value);
                    System.Threading.Interlocked.Increment(ref this.EnqueuedCount);
                }
                catch (Exception ex)
                {
                    if (commonLog.LoggingEnabled)
                    {
                        commonLog.LogEntry("StyleQueue Add Exception", ex);
                    }
                }
                finally
                {
                    System.Threading.Monitor.Exit(this.___AddToQueueLockingObject);
                }
            }
            else
            {
                if (commonLog.LoggingEnabled)
                {
                    commonLog.LogEntry("Uhhh. CHtmlCSSRuleMergeQueue failed to obtain lock.");
                }
            }

            if (this.IsAllCSSComplete == true)
            {
                if (this.IsMergeFunctionEntered == false)
                {
                    if (___StyleStatus == 0)
                    {
                        if (commonLog.LoggingEnabled && commonLog.LogLevel > 100)
                        {
                            ___StyleStatus++;
                            commonLog.LogEntry("Style will be must be mearged as JIT afterword.");
                        }
                    }
                    if (!___needsExitFunctionIfQueueZero)
                    {
                        ___needsExitFunctionIfQueueZero = true;
                    }

                    this.PerformStyleGroudMeargeToGroundList(_cancellationToken);
                }
            }
            return;
        }

        internal int counterPerformStyleGroudMeargeToGroundListEnterd;

        public void InitalizeMeargeThread()
        {
            if (this.___QueueTask == null)
            {
                this.___QueueTask = Task.Run(() => PerformStyleGroudMeargeToGroundList(_cancellationToken), _cancellationToken);
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 1)
                {
                    commonLog.LogEntry("StyleMeargeTaskFor" + this.ShortName + " ___hasInner started");
                }
            }
        }

        public void CompleteMergeProcess()
        {
            this.IsAllCSSComplete = true;
            _cancellationTokenSource.Cancel();
            if (commonLog.LoggingEnabled && commonLog.LogLevel > 1)
            {
                if (this.Count > 0)
                {
                    commonLog.LogEntry("StyleMerge still leave {0} items to mearge...", this.Count);
                }
            }
        }

        private string ConvertStyleUrlIntoFullUrl(string _cssUrl, string ___baseUrl, string _partUri, int _mode)
        {
            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 10)
            {
                commonLog.LogEntry("Need to convert partial url to full url: {0} mode: {1} css: {2}", _partUri, _mode, _cssUrl);
            }
            switch (_mode)
            {
                case 0: // Segment
                    return _partUri;
                default:
                case 1:
                    return commonHTML.GetAbsoluteUri(_cssUrl, "", _partUri);
            }
        }

       // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        internal async Task PerformStyleGroudMeargeToGroundList(CancellationToken cancellationToken)
        {
            DateTime dtPerformStyleGroudMeargeToGroundList = DateTime.Now;
            this.IsMergeFunctionEntered = true;
            counterPerformStyleGroudMeargeToGroundListEnterd++;

            try
            {
                if (this.___parentDocument != null && this.___documentReference == null)
                {
                    this.___documentReference = new WeakReference(this.___parentDocument, false);
                }

                if (this.___parentDocument == null)
                {
                    if (this.___documentReference != null)
                    {
                        this.___parentDocument = this.___documentReference.Target as CHtmlDocument;
                    }
                    if (this.___parentDocument == null)
                    {
                        this.IsMergeFunctionEntered = false;
                        return;
                    }
                }

                System.Collections.Generic.Dictionary<string, ushort> ___CSSAttributeLookupFieldList = this.___parentDocument.___CSSAttributeLookupFieldList;
                System.Collections.Generic.Dictionary<string, ushort> ___CSSNthOfTypeTagTypesList = this.___parentDocument.___CSSNthOfTypeTagTypesList;
                CHtmlCSSRuleGroundList ____DocumentStylesheetGroundList = this.___parentDocument.___cssRuleGroundList;
                string ___DocumentURL = string.Copy(this.___parentDocument.___URL);
                string ___DocumentBaseUrl = null;
                if (string.IsNullOrEmpty(this.___parentDocument.___baseUrl) == false)
                {
                    ___DocumentBaseUrl = string.Copy(this.___parentDocument.___baseUrl);
                }

                CHtmlDocument ___targetDocument = this.___parentDocument;
                int posInsert;
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    int ___CurrentCount = base.Count;
                    if (___CurrentCount == 0)
                    {
                        if (this.___needsExitFunctionIfQueueZero == true)
                        {
                            goto CompletePhase;
                        }
                        if (___needsExitFunctionIfQueueZero == false && ___targetDocument != null && ___targetDocument.___isStyleQueueShouldBeStopedAfterBodyTag == true)
                        {
                            goto CompletePhase;
                        }

                        if (this.___needsExitFunctionIfQueueZero || this.Disposing || ___targetDocument == null || (___targetDocument != null && (___targetDocument.___readyStateType == CHtmlReadytStateType.complete || ___targetDocument.___IsThreadAbortOccurred == true || ___targetDocument.___IsThreadAbortOccurred == true || ___targetDocument.___IsDisposing)))
                        {
                            goto CompletePhase;
                        }

                        await Task.Delay(1000, cancellationToken);
                    }
                    else
                    {
                        CHtmlCSSRule sPart = null;
                        try
                        {
                            sPart = base[0] as CHtmlCSSRule;
                            if (sPart == null)
                            {
                                goto RemoveListPhase;
                            }

                            if (sPart.___CSSHack != CSSHackType.None || sPart.___NonSearchableStyleSheet == true)
                            {
                                if (sPart.___CSSHack == CSSHackType.None)
                                {
                                    switch (sPart.___ruleType)
                                    {
                                        case CHtmlCSSRule.CSSRuleType.Import_Rule:
                                            {
                                                if (string.IsNullOrEmpty(sPart.___baseUrl) == false)
                                                {
                                                    CHtmlElement ___cssTagRootElement = null;
                                                    if (sPart.___srcElementReference != null)
                                                    {
                                                        ___cssTagRootElement = sPart.___srcElementReference.Target as CHtmlElement;
                                                    }
                                                    bool __IsEnqueued = ___targetDocument.___downloadviaQueue(sPart.___baseUrl, "StyleSheet", "", "", "", "", CHtmlThreadPoolQueueObjectType.UrlStyleSheet, sPart.___baseUrl, ___cssTagRootElement, 0, CHtmlUrlSourceType.Unknown, false);
                                                    if (__IsEnqueued)
                                                    {
                                                        ___targetDocument.___IncrementDocumentDownloadCounter();
                                                    }
                                                }
                                            }
                                            break;
                                        default: break;
                                    }
                                }
                                if (___targetDocument.___cssRuleBlackList.Count < 1000)
                                {
                                    if (System.Threading.Monitor.TryEnter(___targetDocument.___cssRuleBlackList, 500))
                                    {
                                        try
                                        {
                                            ___targetDocument.___cssRuleBlackList.Add(sPart);
                                        }
                                        finally
                                        {
                                            System.Threading.Monitor.Exit(___targetDocument.___cssRuleBlackList);
                                        }
                                    }
                                }
                                goto RemoveListPhase;
                            }

                            if (sPart.___AttributesBulkTitleList != null && sPart.___AttributesBulkTitleList.Count > 0)
                            {
                                foreach (string strAttributeKey in sPart.___AttributesBulkTitleList.Keys)
                                {
                                    if (___CSSAttributeLookupFieldList.ContainsKey(strAttributeKey) == false)
                                    {
                                        ___CSSAttributeLookupFieldList[strAttributeKey] = 1;
                                    }
                                }
                            }

                            if (sPart.___ListNthOfTypeTagTypes.Count > 0)
                            {
                                foreach (string strNthOfTagType in sPart.___ListNthOfTypeTagTypes.Keys)
                                {
                                    if (strNthOfTagType == null)
                                        continue;
                                    if (___CSSNthOfTypeTagTypesList.ContainsKey(strNthOfTagType) == false)
                                    {
                                        ___CSSNthOfTypeTagTypesList[strNthOfTagType] = 1;
                                    }
                                }
                            }

                            try
                            {
                                if (counterPerformStyleGroudMeargeToGroundListEnterd > 1)
                                {
                                    if (System.Threading.Monitor.TryEnter(___MergeLockingObject, MAX_WAIT))
                                    {
                                        try
                                        {
                                            if (sPart.___PseudoClassType != CHtmlPseudoClassType.None)
                                            {
                                                ___targetDocument.___CSSDocumentTotalPseudoClass = ___targetDocument.___CSSDocumentTotalPseudoClass | sPart.___PseudoClassType;
                                            }

                                            posInsert = ____DocumentStylesheetGroundList.BinarySearch(sPart, this._GroundStyleSheetNonGenericSorter);
                                            if (posInsert < 0)
                                            {
                                                posInsert = ~posInsert;
                                            }
                                            ___MeargedOrRemovedStyleCount++;
                                            ____DocumentStylesheetGroundList.Insert(posInsert, sPart);
                                            MergedCount++;
                                        }
                                        catch (Exception exInsert)
                                        {
                                            if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                            {
                                                commonLog.LogEntry("CSSRuleMeargeQueue Insert or Merge Exception. ", exInsert);
                                            }
                                        }
                                        finally
                                        {
                                            try
                                            {
                                                System.Threading.Monitor.Exit(___MergeLockingObject);
                                            }
                                            catch { }
                                        }
                                    }
                                    else
                                    {
                                        if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                        {
                                            commonLog.LogEntry("Style Merge Monitor List Lock Failed");
                                        }
                                    }
                                }
                                else
                                {
                                    if (sPart.___PseudoClassType != CHtmlPseudoClassType.None)
                                    {
                                        ___targetDocument.___CSSDocumentTotalPseudoClass = ___targetDocument.___CSSDocumentTotalPseudoClass | sPart.___PseudoClassType;
                                    }
                                    posInsert = ____DocumentStylesheetGroundList.BinarySearch(sPart, this._GroundStyleSheetNonGenericSorter);
                                    if (posInsert < 0)
                                    {
                                        posInsert = ~posInsert;
                                    }
                                    ___MeargedOrRemovedStyleCount++;
                                    ____DocumentStylesheetGroundList.Insert(posInsert, sPart);
                                    MergedCount++;
                                }
                            }
                            catch (Exception exBinarySearch)
                            {
                                if (commonLog.LoggingEnabled && commonLog.LogLevel >= 3)
                                {
                                    commonLog.LogEntry(" Style Merge Queue BinarySearch Failed. ", exBinarySearch.Message);
                                }
                            }

                        RemoveListPhase:
                            if (counterPerformStyleGroudMeargeToGroundListEnterd > 1)
                            {
                                if (System.Threading.Monitor.TryEnter(this.___MergeLockingObject, MAX_WAIT))
                                {
                                    try
                                    {
                                        ___MeargedOrRemovedStyleCount++;
                                        base.RemoveAt(0);
                                    }
                                    finally
                                    {
                                        System.Threading.Monitor.Exit(this.___MergeLockingObject);
                                    }
                                }
                            }
                            else
                            {
                                ___MeargedOrRemovedStyleCount++;
                                base.RemoveAt(0);
                            }
                        }
                        catch (Exception exStyle)
                        {
                            if (commonLog.LoggingEnabled && commonLog.LogLevel > 1)
                            {
                                commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() Style Level", exStyle);
                            }
                        }
                    }
                }

            CompletePhase:
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 1 && this.___needsExitFunctionIfQueueZero == false)
                {
                    TimeSpan tpSpanPerformStyleGroudMeargeToGroundList = DateTime.Now.Subtract(dtPerformStyleGroudMeargeToGroundList);
                    commonLog.LogEntry("CSS PerformStyleGroudMeargeToGroundList() Thread completed with {0} items.  Short Wait : {1} Long Wait : {2} Elapsed : {3} ms...", this.MergedCount, this.___StyleShortWaitOneCount, this.___StyleLongWaitOneCount, tpSpanPerformStyleGroudMeargeToGroundList);
                }

                // イベントの発行
                MergeCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (OperationCanceledException)
            {
                if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                {
                    commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() was canceled.");
                }
            }
            catch (Exception ex)
            {
                if (ex is System.Threading.ThreadAbortException)
                {
                    if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                    {
                        commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() encounters ThreadAbort. Cont..");
                    }
                }
                else if (commonLog.LoggingEnabled && commonLog.LogLevel > 10)
                {
                    commonLog.LogEntry("PerformStyleGroudMeargeToGroundList() exception", ex);
                }
            }
            this.___parentDocument = null;
            this.IsMergeFunctionEntered = false;
        }
    }
}