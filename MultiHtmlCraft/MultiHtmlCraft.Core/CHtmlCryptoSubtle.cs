using System;
using System.Collections.Generic;
using System.Text;
using MultiHtmlCraft.Interfaces;
namespace MultiHtmlCraft.Core
{
    public sealed class CHtmlCryptoSubtle : CHtmlNode , ICommonObjectInterface 
    {
        internal System.WeakReference ___ownerDocumentWeakReference = null;
   

        public string getClassName()
        {
            return "subtle";
        }
        public override string ToString()
        {
            return "subtle";
        }
        public bool hasOwnProperty(string ___name)
        {
            return this.___hasPropertyByName(___name);
        }
        public CHtmlCryptoOperation decrypt(object ___obj_algorithm, object ___obj_key, object ___obj_buffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.decrypt() calling", this);
            }
            CHtmlCryptoOperation ___decryptOperation = new CHtmlCryptoOperation();

            return ___decryptOperation;
        }
        public CHtmlCryptoOperation digest(object ___obj_algorithm, object ___obj_buffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.digest() calling", this);
            }
            CHtmlCryptoOperation ___decryptOperation = new CHtmlCryptoOperation();

            return ___decryptOperation;
        }
        public CHtmlCryptoOperation encrypt(object ___obj_algorithm, object ___obj_buffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.encrypt() calling", this);
            }
            CHtmlCryptoOperation ___decryptOperation = new CHtmlCryptoOperation();

            return ___decryptOperation;
        }
        public CHtmlCryptoOperation sign(object ___obj_algorithm, object ___obj_buffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.sign() calling", this);
            }
            CHtmlCryptoOperation ___decryptOperation = new CHtmlCryptoOperation();

            return ___decryptOperation;
        }
        public CHtmlCryptoOperation verify(object ___obj_algorithm, object ___obj_key, object ___obj_signature, object ___obj_buffer)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.verify() calling", this);
            }
            CHtmlCryptoOperation ___verifyOperation = new CHtmlCryptoOperation();
            return ___verifyOperation;
        }
        public CHtmlCryptoKeyOperation deriveKey(object ___obj_algorithm, object ___obj_baseKey, object ___obj_derivedKeyType, object ___obj_extractable, object ___obj_keyUsages)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.deriveKey() calling", this);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }
        public CHtmlCryptoKeyOperation exportKey(object ___obj_format, object ___obj_key)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.exportKey() calling", this);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }

        public CHtmlCryptoKeyOperation generateKey(object ___obj_algorithm, object ___obj_extractable, object ___obj_keyUsages)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.generateKey({1}, {2}, {3})", this, ___obj_algorithm, ___obj_extractable , ___obj_keyUsages);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }
        public CHtmlCryptoKeyOperation importKey(object ___obj_format, object ___obj_keyData, object ___obj_algorithm, object ___obj_extractable, object ___obj_keyUsages)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.importKey({1}, {2}, {3}, {4}, {5})", this, ___obj_format, ___obj_keyData, ___obj_algorithm, ___obj_extractable, ___obj_keyUsages);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }
        public CHtmlCryptoKeyOperation unwrapKey(object ___obj_format, object ___obj_keyData, object ___obj_algorithm, object ___obj_extractable, object ___obj_keyUsages)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.unwrapKey({1}, {2}, {3}, {4}, {5})", this, ___obj_format, ___obj_keyData, ___obj_algorithm, ___obj_extractable, ___obj_keyUsages);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }
        public CHtmlCryptoKeyOperation wrapKey(object ___obj_key, object ___obj_keyEncryptionKey, object ___obj_keyWrappingAlgorithm)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 5)
            {
               commonLog.LogEntry("TODO: entering {0}.wrapKey({1}, {2}, {3})", this, ___obj_key, ___obj_keyEncryptionKey, ___obj_keyWrappingAlgorithm);
            }
            CHtmlCryptoKeyOperation ___keyOperation = new CHtmlCryptoKeyOperation();
            return ___keyOperation;
        }


        #region IPropertBox メンバ

        public object ___getPropertyByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} ", this, ___name);
            }
            switch (___name)
            {
                default:
                    break;
            }
            object propValue;
            if (___properties.TryGetValue(___name, out propValue))
            {
                return propValue;
            }
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValue for {0} {1} failed", this, ___name);
            }
            return null;
        }

        public void ___setPropertyByName(string ___name, object val)
        {
            switch (___name)
            {
                default:
                    if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
                    {
                       commonLog.LogEntry("SetPropertyValue for {0} {1}  {2} = {3} failed", this.GetType(), this, ___name, val);
                    }
                    this.___properties[___name] = val;
                    break;
            }
        }
        public void ___setPropertyByIndex(int ___index, object val)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("SetPropertyValueIndex for {0} {1}  {2} = {3} failed", this.GetType(), this, ___index, val);
            }
        }
        public object ___getPropertyByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 8)
            {
               commonLog.LogEntry("GetPropertyValueInex for {0} {1} {2} failed", this.GetType(), this, ___index);
            }
            return null;
        }

        public bool ___hasPropertyByName(string ___name)
        {

            return false;
        }
        public bool ___hasPropertyByIndex(int ___index)
        {
            return true;
        }
        public object ___common_object_clone()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("x__Clone {0} {1} called", this.GetType(), this);
            }
            return this;
        }
        public void ___deleteByIndex(int ___index)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByIndex {0} {1} called : {2}", this.GetType(), this, ___index);
            }
        }
        public void ___deleteByName(string ___name)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___deleteByName {0} {1} called : {2}", this.GetType(), this, ___name);
            }

        }
        public object[] ___getByIds()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getByIds() {0} {1} called", this.GetType(), this);
            }
            return null;

        }
        public string ___getClassName()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getClassName {0} {1} called", this.GetType(), this);
            }
            return this.GetType().Name;
        }
        public object ___getDefaultValue()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getDefaultValue {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public object ___getParentScope()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getParentScope {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public void ___setParentScope(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setParentScope {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }
        public object ___getProtoType()
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___getProtoType {0} {1} called", this.GetType(), this);
            }
            return null;
        }
        public bool ___hasInstance(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___hasInstance {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return false;
        }
        public bool ___instanceEquals(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___instanceEquals {0} {1} called : {2}", this.GetType(), this, ___object);
            }
            return object.ReferenceEquals(this, ___object);
        }
        public void ___setProtoType(object ___object)
        {
            if (commonLog.LoggingEnabled &&commonLog.LogLevel >= 10)
            {
               commonLog.LogEntry("___setProtoType {0} {1} called : {2}", this.GetType(), this, ___object);
            }
        }

        #endregion
    }
}
