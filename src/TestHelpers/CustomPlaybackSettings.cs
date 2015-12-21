namespace TestHelpers
{
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;

    public class CustomPlaybackSettings
    {
        /// <summary> Test startup. </summary>
        public static void Initialize()
        {
            // Configure the playback engine
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.MaximumRetryCount = 10;
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.DelayBetweenActions = 500;
            Playback.PlaybackSettings.SearchTimeout = 1000;

            // Add the error handler
            Playback.PlaybackError -= OnPlaybackError; // Remove the handler if it's already added
            Playback.PlaybackError += OnPlaybackError; // Ta dah...
        }

        /// <summary> PlaybackError event handler. </summary>
        private static void OnPlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            // Wait a second
            System.Threading.Thread.Sleep(1000);

            // Retry the failed test operation
            e.Result = PlaybackErrorOptions.Retry;
        }
    }
}
