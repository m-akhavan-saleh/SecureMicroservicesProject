﻿using IdentityServer;
using IdentityServer4.Models;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddIdentityServer();   // اضافه کردن به لیست سرویس ها

builder.Services.AddIdentityServer() // اضافه کردن به لیست سرویس به همراه انجام تنظیمات لازم
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddTestUsers(Config.TestUsers)
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseIdentityServer(); // استفاده از سرویس در برنامه

app.MapGet("/", () => "Hello World!");

app.Run();