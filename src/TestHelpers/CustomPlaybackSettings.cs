namespace TestHelpers
{
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;

    public class CustomPlaybackSettings
    {
        /// <summary> Test startup. </summary>
        public static void Initialize()
        {
            // Configure the playback engine
            //Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            //Playback.PlaybackSettings.MaximumRetryCount = 10;
            //Playback.PlaybackSettings.ShouldSearchFailFast = false;
            //Playback.PlaybackSettings.DelayBetweenActions = 500;
            //Playback.PlaybackSettings.SearchTimeout = 1000;

            Trace.WriteLine(string.Format("Playback.PlaybackSettings.AlwaysSearchControls: {0}", Playback.PlaybackSettings.AlwaysSearchControls));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.ContinueOnError: {0}", Playback.PlaybackSettings.ContinueOnError));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.DelayBetweenActions: {0}", Playback.PlaybackSettings.DelayBetweenActions));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.MaximumRetryCount: {0}", Playback.PlaybackSettings.MaximumRetryCount));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.MatchExactHierarchy: {0}", Playback.PlaybackSettings.MatchExactHierarchy));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.SearchInMinimizedWindows: {0}", Playback.PlaybackSettings.SearchInMinimizedWindows));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.SearchTimeout: {0}", Playback.PlaybackSettings.SearchTimeout));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.SendKeysAsScanCode: {0}", Playback.PlaybackSettings.SendKeysAsScanCode));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.ShouldSearchFailFast: {0}", Playback.PlaybackSettings.ShouldSearchFailFast));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.SkipSetPropertyVerification: {0}", Playback.PlaybackSettings.SkipSetPropertyVerification));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.SmartMatchOptions: {0}", Playback.PlaybackSettings.SmartMatchOptions));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.ThinkTimeMultiplier: {0}", Playback.PlaybackSettings.ThinkTimeMultiplier));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.WaitForReadyLevel: {0}", Playback.PlaybackSettings.WaitForReadyLevel));
            Trace.WriteLine(string.Format("Playback.PlaybackSettings.WaitForReadyTimeout: {0}", Playback.PlaybackSettings.WaitForReadyTimeout));

            // Add the error handler
            //Playback.PlaybackError -= OnPlaybackError; // Remove the handler if it's already added
            //Playback.PlaybackError += OnPlaybackError; // Ta dah...
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
