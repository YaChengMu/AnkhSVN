using System;

namespace Ankh.Commands
{
    /// <summary>
    /// A command that lets the user send a generic error report.
    /// </summary>
    [VSNetCommand("SendErrorReport", Text = "Send suggestion/error report", 
         Tooltip = "Show the repository explorer window",
         Bitmap = ResourceBitmaps.SendSuggest),
    VSNetControl( "Tools.AnkhSVN", Position = 1 )]
    public class SendErrorReportCommand : CommandBase
    {
        public SendErrorReportCommand(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public override EnvDTE.vsCommandStatus QueryStatus(IContext context)
        {
            // always enabled.
            return Enabled;
        }

        public override void Execute(IContext context, string parameters)
        {
            context.ErrorHandler.SendReport();
        }


    }
}
