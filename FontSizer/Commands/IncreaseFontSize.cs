namespace FontSizer.Commands {
    using System;
    using System.ComponentModel.Design;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    internal sealed class IncreaseFontSize : FontSizeCommandBase {

        readonly Package _package;
        public const Int32 CommandId = 0x0100;

        public static readonly Guid CommandSet = new Guid("fcca8c63-3b62-4b25-aad1-e644cc9528cc");

        public static IncreaseFontSize Instance { get; private set; }

        IServiceProvider ServiceProvider {
            get { return _package; }
        }

        IncreaseFontSize(Package package) {
            if (package == null) {
                throw new ArgumentNullException(nameof(package));
            }

            _package = package;

            var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null) {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(HandleIncreaseFont, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        void HandleIncreaseFont(Object sender, EventArgs e) {
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.TextEditor), 2);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.StatementCompletion), 1);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.TextOutputToolWindows), 1);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.Tooltip), 1);
            AdjustFontSize(this.ServiceProvider, new Guid(CodeLensCategory), 1);
        }

        public static void Initialize(Package package) {
            Instance = new IncreaseFontSize(package);
        }

    }
}
