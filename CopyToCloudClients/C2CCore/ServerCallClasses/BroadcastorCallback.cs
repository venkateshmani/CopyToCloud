using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C2CWindowsDesktopClient.WebServices;
using System.ComponentModel;

namespace C2CWindowsDesktopClient.ServerCallClasses
{
    public class BroadcastorCallback : IC2CServiceCallback
    {
        private System.Threading.SynchronizationContext m_SyncContext = AsyncOperationManager.SynchronizationContext;

        private EventHandler m_BroadcastorCallBackHandler;
        public void SetHandler(EventHandler handler)
        {
            m_BroadcastorCallBackHandler = handler;
        }

        public void BroadcastToMyOwnClients(CopiedDetails details)
        {
            m_SyncContext.Post(new System.Threading.SendOrPostCallback(OnBroadcast), details);
        }

        private void OnBroadcast(object details)
        {
            m_BroadcastorCallBackHandler.Invoke(details, null);
        }
    }
}
