﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MonkeyFinder.Services;
using MonkeyFinder.ViewModel;

namespace MonkeyFinder;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		  
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddTransient<MonkeysViewModel>();
		return builder.Build();
	}
}
