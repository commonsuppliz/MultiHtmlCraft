using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiHtmlCraft.Interfaces
{
    public interface ICHtmlWorker
    {   /// <summary>
        /// Base URL for the worker window
        /// </summary>
        string baseUrl { get; set; }


        


        /// <summary>
        /// Adds an event listener for the specified event type
        /// </summary>
        /// <param name="type">Event type</param>
        /// <param name="handler">Event handler</param>
        void addEventListener(string type, EventHandler handler);

        /// <summary>
        /// Removes an event listener for the specified event type
        /// </summary>
        /// <param name="type">Event type</param>
        /// <param name="handler">Event handler</param>
        void removeEventListener(string type, EventHandler handler);

        /// <summary>
        /// Dispatches an event to the worker
        /// </summary>
        /// <param name="evt">Event object</param>
        /// <returns>true if the event was handled, false otherwise</returns>
        bool dispatchEvent(object evt);
    }
}
