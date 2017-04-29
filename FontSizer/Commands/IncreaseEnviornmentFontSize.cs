namespace FontSizer.Commands {
    using System;
    using System.ComponentModel.Design;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    internal sealed class IncreaseEnviornmentFontSize : FontSizeCommandBase {

        readonly Package package;
        public const Int32 CommandId = 4130;

        public static readonly Guid CommandSet = new Guid("fcca8c63-3b62-4b25-aad1-e644cc9528cc");

        public static IncreaseEnviornmentFontSize Instance { get; private set; }

        IServiceProvider ServiceProvider {
            get { return package; }
        }

        IncreaseEnviornmentFontSize(Package package) {
            if (package == null) {
                throw new ArgumentNullException(nameof(package));
            }

            this.package = package;

            var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null) {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(HandleIncreaseEnviornmentFontSize, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static void Initialize(Package package) {
            Instance = new IncreaseEnviornmentFontSize(package);
        }

        void HandleIncreaseEnviornmentFontSize(Object sender, EventArgs e) {
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.DialogsAndToolWindows), 2);
        }

    }
}
