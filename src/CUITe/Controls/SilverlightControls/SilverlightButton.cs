﻿#if SILVERLIGHT_SUPPORT
using CUITControls = Microsoft.VisualStudio.TestTools.UITesting.SilverlightControls;

namespace CUITe.Controls.SilverlightControls
{
    /// <summary>
    /// CUITe wrapper for SilverlightButton.
    /// </summary>
    public class SilverlightButton : SilverlightControl<CUITControls.SilverlightButton>
    {
        public SilverlightButton() { }
        public SilverlightButton(string searchParameters) : base(searchParameters) { }

        /// <summary>
        /// Gets the text displayed on the Silverlight Button.
        /// </summary>
        public string DisplayText
        {
            get
            {
                _control.WaitForControlReady();
                return _control.DisplayText;
            }
        }
    }
}
#endif