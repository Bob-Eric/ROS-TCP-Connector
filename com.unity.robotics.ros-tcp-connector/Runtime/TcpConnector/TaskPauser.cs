using System.Threading;
using System.Threading.Tasks;

namespace Unity.Robotics.ROSTCPConnector
{
    public class TaskPauser
    {
        CancellationTokenSource m_Source = new CancellationTokenSource();
        public object Result { get; private set; }

        public async Task<object> PauseUntilResumed()
        {
            try
            {
                while (!m_Source.Token.IsCancellationRequested)
                {
                    await Task.Delay(10000, m_Source.Token);
                }
            }
            catch (TaskCanceledException)
            {

            }
            return Result;
        }

        public void Resume(object result)
        {
            Result = result;
            m_Source.Cancel();
        }
    }
}
