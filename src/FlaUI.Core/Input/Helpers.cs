using System.Threading;

namespace FlaUI.Core.Input
{
    public static class Helpers
    {
        public static void WaitUntilInputIsProcessed()
        {
            // Let the thread some time to process the system's hardware input queue.
            // For details see this post: http://blogs.msdn.com/b/oldnewthing/archive/2014/02/13/10499047.aspx
            // TODO: Should this be configurable?
            Thread.Sleep(100);
        }
    }
}
