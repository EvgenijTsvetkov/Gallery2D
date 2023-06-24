using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Gallery.Source.Extensions
{
    public static class UnityWebRequestExtension
    {
        public static TaskAwaiter<UnityWebRequest.Result> GetAwaiter(this UnityWebRequestAsyncOperation requestOperation)
        {
            TaskCompletionSource<UnityWebRequest.Result> taskCompletionSource = new();
            requestOperation.completed +=
                asyncOp => taskCompletionSource.TrySetResult(requestOperation.webRequest.result);

            if (requestOperation.isDone)
                taskCompletionSource.TrySetResult(requestOperation.webRequest.result);

            return taskCompletionSource.Task.GetAwaiter();
        }
    }
}
