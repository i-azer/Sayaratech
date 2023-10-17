using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sayaratech;

[Dependency(ReplaceServices = true)]
public class SayaratechBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Sayaratech";
}
