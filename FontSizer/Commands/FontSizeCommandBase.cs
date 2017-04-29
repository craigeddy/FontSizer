namespace FontSizer.Commands {
    using System;
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell.Interop;

    internal abstract class FontSizeCommandBase {

        protected const String CodeLensCategory = "{FC88969A-CBED-4940-8F48-142A503E2381}";

        protected FontSizeCommandBase() {
        }

        protected void AdjustFontSize(IServiceProvider serviceProvider, Guid category, short change) {
            var storage = (IVsFontAndColorStorage)serviceProvider.GetService(typeof(SVsFontAndColorStorage));
            // ReSharper disable once SuspiciousTypeConversion.Global
            var utilities = storage as IVsFontAndColorUtilities;
            if (utilities == null) {
                return;
            }

            var pLOGFONT = new LOGFONTW[1];
            var pInfo = new FontInfo[1];

            ErrorHandler.ThrowOnFailure(storage.OpenCategory(category, (uint)(__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS | __FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES)));
            try {
                if (!ErrorHandler.Succeeded(storage.GetFont(pLOGFONT, pInfo))) {
                    return;
                }

                pInfo[0].wPointSize = checked((ushort)(pInfo[0].wPointSize + change));
                ErrorHandler.ThrowOnFailure(storage.SetFont(pInfo));
                ErrorHandler.ThrowOnFailure(utilities.FreeFontInfo(pInfo));
            } finally {
                storage.CloseCategory();
            }
        }

    }
}
