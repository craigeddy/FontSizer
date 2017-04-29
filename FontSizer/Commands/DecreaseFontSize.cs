namespace FontSizer.Commands {
    using System;
    using System.ComponentModel.Design;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    internal sealed class DecreaseFontSize : FontSizeCommandBase {

        readonly Package _package;
        public const Int32 CommandId = 4129;

        public static readonly Guid CommandSet = new Guid("fcca8c63-3b62-4b25-aad1-e644cc9528cc");

        public static DecreaseFontSize Instance { get; private set; }

        IServiceProvider ServiceProvider {
            get { return _package; }
        }

        DecreaseFontSize(Package package) {
            if (package == null) {
                throw new ArgumentNullException(nameof(package));
            }

            _package = package;

            var commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null) {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new MenuCommand(HandleDecreaseFontSize, menuCommandID);
                commandService.AddCommand(menuItem);
            }
        }

        public static void Initialize(Package package) {
            Instance = new DecreaseFontSize(package);
        }

        void HandleDecreaseFontSize(Object sender, EventArgs e) {
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.TextEditor), -2);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.StatementCompletion), -1);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.TextOutputToolWindows), -1);
            AdjustFontSize(this.ServiceProvider, new Guid(FontsAndColorsCategory.Tooltip), -1);
            AdjustFontSize(this.ServiceProvider, new Guid(CodeLensCategory), -1);

        }

    }
}
