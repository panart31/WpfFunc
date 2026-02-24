using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfFunc.Localization;

// Markup-расширение для локализации
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

