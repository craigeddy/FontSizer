namespace FontSizer.Commands {
    using System;
    using System.ComponentModel.Design;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    internal sealed class DecreaseEnviornmentFontSize : FontSizeCommandBase {

        readonly Package _package;
        public const Int32 CommandId = 4131;

        public static readonly Guid CommandSet = new Guid("fcca8c63-3b62-4b25-aad1-e644cc9528cc");

        public static DecreaseEnviornmentFontSize Instance { get; private set; }

        IServiceProvider ServiceProvider {
            get { return _package; }
        }

        DecreaseEnviornmentFontSize(Package package) {
            if (package == null) {
                throw new ArgumentNullException(nameof(package));
            }

            this._package = package;

            var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null) {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(HandleDecreaseEnviornmentFontSize, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static void Initialize(Package package) {
            Instance = new DecreaseEnviornmentFontSize(package);
        }

        void HandleDecreaseEnviornmentFontSize(Object sender, EventArgs e) {
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.DialogsAndToolWindows), -2);
        }

    }
}
