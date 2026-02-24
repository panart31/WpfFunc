using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfFunc.Localization;

/// <summary>
/// Markup-расширение для удобной привязки локализованных строк:
/// Text="{loc:Loc Key=Default.Title}".
/// </summary>
[MarkupExtensionReturnType(typeof(BindingExpression))]
public class LocExtension : MarkupExtension
{
    public string Key { get; set; } = string.Empty;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        if (string.IsNullOrWhiteSpace(Key))
            return string.Empty;

        var binding = new Binding($"[{Key}]")
        {
            Source = LocalizationManager.Instance,
            Mode = BindingMode.OneWay
        };

        return binding.ProvideValue(serviceProvider);
    }
}

