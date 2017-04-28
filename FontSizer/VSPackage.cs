namespace FontSizer {
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using FontSizer.Commands;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuidString)]
    [ProvideAutoLoad(UIContextGuids.SolutionExists)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class VSPackage : Microsoft.VisualStudio.Shell.Package {

        public const string PackageGuidString = "1099b5c0-7023-4762-9cd9-008d1219c716";

        public VSPackage() {
        }

        protected override void Initialize() {
            IncreaseFontSize.Initialize(this);
            DecreaseFontSize.Initialize(this);
            base.Initialize();
        }

    }
}
