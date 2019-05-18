﻿using ElectronNET.API;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElectronNET_API_Demos.Controllers
{
    public class ProgressBarController : Controller
    {
        public IActionResult Index()
        {
            if (HybridSupport.IsElectronActive)
            {
                Electron.IpcMain.On("set-progress-bar", async (args) =>
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                    mainWindow.SetProgressBar(0.5);
                });

                Electron.IpcMain.On("clear-progress-bar", async (args) =>
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                    mainWindow.SetProgressBar(-1);
                });
            }

            return View();
        }
    }
}
