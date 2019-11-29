using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace CodecQueryException
{
  
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      InitializeComponent();
      Init();
    }
    private async void Init()
    {
      try
      {
        await GetCodecs();
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Exception::{ex.Message}");
      }
    }

    public async Task GetCodecs()
    {
      var codecQuery = new CodecQuery();
      //IReadOnlyList<CodecInfo> result = await codecQuery.FindAllAsync(CodecKind.Video, CodecCategory.Encoder, "");
      IReadOnlyList<CodecInfo> result = await codecQuery.FindAllAsync(CodecKind.Audio, CodecCategory.Decoder, "");
      foreach (var codecInfo in result)
      {
        TB.Text += "============================================================\n";
        TB.Text += $"Codec: {codecInfo.DisplayName}\n";
        TB.Text += $"Kind: {codecInfo.Kind}\n";
        TB.Text += $"Category: {codecInfo.Category}\n";
        TB.Text += $"Trusted: {codecInfo.IsTrusted}\n";

        foreach (string subType in codecInfo.Subtypes)
        {
          TB.Text += $"   Subtype: {subType}\n";

        }
      }

    }
  }
}
