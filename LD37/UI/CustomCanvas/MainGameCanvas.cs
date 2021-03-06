﻿using LD37.Entities.Machines;
using LD37.Entities.Resources;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Diagnostics;

namespace LD37.UI
{
    public class MainGameCanvas : UICanvas
    {

        public ConstructionManager constructionManager;

        public bool isBuilding = false;
        public bool isOverUI;

        UIText money;
        UIText buildMode;
        UIText buildRotation;
        UIText timePlayed;

        UIButton openMenu;
        UIPanel mainPanel;
        UIPanel buildPanel;
        UIPanel machinePanel;

        List<UIButton> machines = new List<UIButton>();

        UIButton imp;
        UIButton enterBuildMode;

        UIButton exitBuildMode;
        UIButton sellMachine;

        UIPanel impWin;
        UIPanel batteryPanel;
        UIPanel leatherPanel;
        UIPanel plasticPanel;

        UIText batteryTitle;
        UIText leatherTitle;
        UIText plasticTitle;

        UIText batteryCost;
        UIText leatherCost;
        UIText plasticCost;

        UIButton batteryButton;
        UIButton leatherButton;
        UIButton plasticButton;

        UIText impTitle;

        public SortingMachine selectedSortingMachine;
        public UIPanel sortingSettings;
        UIText sortingSettingsTitle;

        UIPanel sortingbatteryPanel;
        UIPanel sortingleatherPanel;
        UIPanel sortingplasticPanel;

        UIButton closeSorting;

        UIText sortingbatteryTitle;
        UIText sortingleatherTitle;
        UIText sortingplasticTitle;

        UIButton sortingbatteryButtonUp;
        UIButton sortingbatteryButtonDown;
        UIButton sortingbatteryButtonRight;

        UIButton sortingleatherButtonUp;
        UIButton sortingleatherButtonDown;
        UIButton sortingleatherButtonRight;

        UIButton sortingplasticButtonUp;
        UIButton sortingplasticButtonRight;
        UIButton sortingplasticButtonDown;

        int windowWidth = 1280;
        int windowHeight = 720;
        int padding = 5;

        int menuBtnW = 100;
        int menuBtnH = 50;

        int impW = 200;
        int impH = 50;

        int resW = 180;
        int resH = 50;

        int impWindowW = 1000;
        int impWindowH = 600;

        int exitBuildW = 260;
        int exitBuildH = 50;

        int sellW = 210;
        int sellH = 50;

        int machinePanelW = 905;
        int machinePanelH = 45;

        int machine0W = 150;
        int machine0H = 40;

        int machine1W = 170;
        int machine1H = 40;

        int machine2W = 280;
        int machine2H = 40;

        int machine3W = 280;
        int machine3H = 40;

        int impItemPanleW = 800;
        int impItemPanleH = 50;

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            money = (UIText)CreateUIElement(new UIText(new Vector2(padding, 0), "Money: $1 000 000"));
            buildMode = (UIText)CreateUIElement(new UIText(new Vector2(padding, 30), "Build Mode: "));
            buildRotation = (UIText)CreateUIElement(new UIText(new Vector2(padding, 60), "Build Rotation: "));
            timePlayed = (UIText)CreateUIElement(new UIText(new Vector2(padding, 120), "Time Played: "));

            openMenu = (UIButton)CreateUIElement(new UIButton("Menu", new Rectangle(windowWidth - menuBtnW, windowHeight - menuBtnH, menuBtnW, menuBtnH), new Vector2(10, 5)));
            mainPanel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(0, windowHeight - menuBtnH, windowWidth - menuBtnW, menuBtnH)));
            mainPanel.visible = false;

            imp = (UIButton)mainPanel.CreateUIElement(new UIButton("Import Elf", new Rectangle(0 + padding, windowHeight - impH, impW, impH), new Vector2(10, 5), WindowTheme.Light));
            enterBuildMode = (UIButton)mainPanel.CreateUIElement(new UIButton("Build Mode", new Rectangle(impW + padding * 2, windowHeight - resH, resW, resH), new Vector2(10, 5), WindowTheme.Light));

            impWin = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - impWindowW / 2, windowHeight / 2 - impWindowH / 2, impWindowW, impWindowH)));
            impWin.visible = false;
            impTitle = (UIText)impWin.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + 40 + padding), "Import Elf Department"));

            batteryPanel = (UIPanel)impWin.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH + 150, impItemPanleW, impItemPanleH), WindowTheme.Light));
            batteryTitle = (UIText)batteryPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH + 150 + padding), "Battery"));
            batteryCost = (UIText)batteryPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding + 200, impH + 150 + padding), Battery.BatteryPrice.ToString() + "$"));
            batteryButton = (UIButton)batteryPanel.CreateUIElement(new UIButton("Order", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH + 150 + padding / 2, 100, 45), new Vector2(10, 2.5f)));

            leatherPanel = (UIPanel)impWin.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH * 2 + 150 + padding, impItemPanleW, impItemPanleH), WindowTheme.Light));
            leatherTitle = (UIText)leatherPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH * 2 + 150 + padding * 2), "Leather"));
            leatherCost = (UIText)leatherPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding + 200, impH * 2 + 150 + padding * 2), Leather.LeatherPrice.ToString() + "$"));
            leatherButton = (UIButton)leatherPanel.CreateUIElement(new UIButton("Order", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH * 2 + 150 + padding / 2 * 4, 100, 45), new Vector2(10, 2.5f)));

            plasticPanel = (UIPanel)impWin.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH * 3 + 150 + padding * 2, impItemPanleW, impItemPanleH), WindowTheme.Light));
            plasticTitle = (UIText)plasticPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH * 3 + 150 + padding * 3), "Plastic"));
            plasticCost = (UIText)plasticPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding + 200, impH * 3 + 150 + padding * 3), Plastic.PlasticPrice.ToString() + "$"));
            plasticButton = (UIButton)plasticPanel.CreateUIElement(new UIButton("Order", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH * 3 + 150 + padding / 2 * 6, 100, 45), new Vector2(10, 2.5f)));


            buildPanel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(0, windowHeight - menuBtnH, windowWidth - menuBtnW, menuBtnH)));
            buildPanel.visible = false;

            exitBuildMode = (UIButton)buildPanel.CreateUIElement(new UIButton("Exit Build Mode", new Rectangle(0 + padding, windowHeight - exitBuildH, exitBuildW, exitBuildH), new Vector2(10, 5), WindowTheme.Light));
            sellMachine = (UIButton)buildPanel.CreateUIElement(new UIButton("Sell Machine", new Rectangle(exitBuildW + padding * 2, windowHeight - sellH, sellW, sellH), new Vector2(10, 5), WindowTheme.Light));

            machinePanel = (UIPanel)buildPanel.CreateUIElement(new UIPanel(new Rectangle(windowWidth - machinePanelW - menuBtnW - padding, windowHeight - machinePanelH - 50, machinePanelW, machinePanelH), WindowTheme.Light));

            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Air Pump", new Rectangle(windowWidth - menuBtnW - machine0W - padding * 2, windowHeight - machine0H - 50, machine0W, machine0H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Assembler", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - padding * 3, windowHeight - machine1H - 50, machine1W, machine1H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Transporter Belt", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - padding * 4, windowHeight - machine2H - 50, machine2W, machine2H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Sorting Machine", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - machine3W - padding * 5, windowHeight - machine3H - 50, machine3W, machine3H), new Vector2(10, 0), WindowTheme.Dark)));

            sortingSettings = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - impWindowW / 2, windowHeight / 2 - impWindowH / 2, impWindowW, impWindowH)));
            sortingSettings.visible = false;
            sortingSettingsTitle = (UIText)sortingSettings.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + 40 + padding), "Sorting Machine Settings"));
            closeSorting = (UIButton)sortingSettings.CreateUIElement(new UIButton("Close", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH * 4 + 150 + padding / 2 * 6, 100, 45), new Vector2(10, 2.5f), WindowTheme.Light));

            sortingbatteryPanel = (UIPanel)sortingSettings.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH + 150, impItemPanleW, impItemPanleH), WindowTheme.Light));
            sortingbatteryTitle = (UIText)sortingbatteryPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH + 150 + padding), "Battery"));
            sortingbatteryButtonUp = (UIButton)sortingbatteryPanel.CreateUIElement(new UIButton("Up", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH + 150 + padding / 2, 100, 45), new Vector2(10, 2.5f)));
            sortingbatteryButtonRight = (UIButton)sortingbatteryPanel.CreateUIElement(new UIButton("Right", new Rectangle(impWin.size.X + impWindowW - 110 - 200 - padding, impH + 150 + padding / 2, 100, 45), new Vector2(10, 2.5f)));
            sortingbatteryButtonDown = (UIButton)sortingbatteryPanel.CreateUIElement(new UIButton("Down", new Rectangle(impWin.size.X + impWindowW - 110 * 2 - 200 - padding, impH + 150 + padding / 2, 100, 45), new Vector2(10, 2.5f)));

            sortingleatherPanel = (UIPanel)sortingSettings.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH * 2 + 150 + padding, impItemPanleW, impItemPanleH), WindowTheme.Light));
            sortingleatherTitle = (UIText)sortingleatherPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH * 2 + 150 + padding * 2), "Leather"));
            sortingleatherButtonUp = (UIButton)sortingleatherPanel.CreateUIElement(new UIButton("Up", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH * 2 + 150 + padding / 2 * 4, 100, 45), new Vector2(10, 2.5f)));
            sortingleatherButtonRight = (UIButton)sortingleatherPanel.CreateUIElement(new UIButton("Right", new Rectangle(impWin.size.X + impWindowW - 110 - 200 - padding, impH * 2 + 150 + padding / 2 * 4, 100, 45), new Vector2(10, 2.5f)));
            sortingleatherButtonDown = (UIButton)sortingleatherPanel.CreateUIElement(new UIButton("Down", new Rectangle(impWin.size.X + impWindowW - 110 * 2 - 200 - padding, impH * 2 + 150 + padding / 2 * 4, 100, 45), new Vector2(10, 2.5f)));

            sortingplasticPanel = (UIPanel)sortingSettings.CreateUIElement(new UIPanel(new Rectangle(impWin.size.X + impWindowW / 2 - impItemPanleW / 2, impH * 3 + 150 + padding * 2, impItemPanleW, impItemPanleH), WindowTheme.Light));
            sortingplasticTitle = (UIText)sortingplasticPanel.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - impItemPanleW / 2 + padding, impH * 3 + 150 + padding * 3), "Plastic"));
            sortingplasticButtonUp = (UIButton)sortingplasticPanel.CreateUIElement(new UIButton("Up", new Rectangle(impWin.size.X + impWindowW - 200 - padding, impH * 3 + 150 + padding / 2 * 6, 100, 45), new Vector2(10, 2.5f)));
            sortingplasticButtonRight = (UIButton)sortingplasticPanel.CreateUIElement(new UIButton("Right", new Rectangle(impWin.size.X + impWindowW - 110 - 200 - padding, impH * 3 + 150 + padding / 2 * 6, 100, 45), new Vector2(10, 2.5f)));
            sortingplasticButtonDown = (UIButton)sortingplasticPanel.CreateUIElement(new UIButton("Down", new Rectangle(impWin.size.X + impWindowW - 110 * 2 - 200 - padding, impH * 3 + 150 + padding / 2 * 6, 100, 45), new Vector2(10, 2.5f)));
        }

        public override void Update(GameTime gameTime)
        {
            money.text = "Money:  $" + StatManager.Instance.GetMoney;
            buildMode.text = "Build Tool: " + constructionManager.BuildMode;
            buildRotation.text = "Build Direction: " + constructionManager.BuildDirection;
            timePlayed.text = "Time Left: " + (GameManager.Instance.GameLength / 1000).ToString() + "s";

            if (selectedSortingMachine != null)
            {
                sortingbatteryTitle.text = "Battery - " + selectedSortingMachine.SortDirection[typeof(Battery)];
                sortingleatherTitle.text = "Leather - " + selectedSortingMachine.SortDirection[typeof(Leather)];
                sortingplasticTitle.text = "Plastic - " + selectedSortingMachine.SortDirection[typeof(Plastic)];
            }

            imp.Update(gameTime);
            impWin.Update(gameTime);
            enterBuildMode.Update(gameTime);
            exitBuildMode.Update(gameTime);
            sellMachine.Update(gameTime);

            base.Update(gameTime);

            for (int i = 0; i < machines.Count; i++)
            {
                machines[i].Update(gameTime);
            }

            #region overUICheck

            Rectangle temp = new Rectangle(0, windowHeight - 100, windowWidth, 100);
            if (temp.Contains(InputManager.Instance.getMousePos()))
            {
                isOverUI = true;
            }
            else
            {
                isOverUI = false;
            }

            #endregion

            #region buttonChecks
            if (isBuilding)
            {
                if (exitBuildMode.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    Debug.WriteLine("Exit Build Mode Pressed");
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.None;
                    mainPanel.visible = true;
                    buildPanel.visible = false;
                    isBuilding = false;
                    return;
                }

                if (machines[0].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.AirPump;
                    mainPanel.visible = false;
                    return;
                }

                if (machines[1].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.Assembler;
                    mainPanel.visible = false;
                    return;
                }

                if (machines[2].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.TransportBelt;
                    mainPanel.visible = false;
                    return;
                }

                if (machines[3].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.SortingMachine;
                    mainPanel.visible = false;
                    return;
                }

                if (sellMachine.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.Sell;
                    mainPanel.visible = false;
                    return;
                }
            }

            if (enterBuildMode.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("Enter Build Mode Pressed");
                mainPanel.visible = false;
                buildPanel.visible = true;
                isBuilding = true;
                return;
            }

            if (imp.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("Import Button Pressed");
                impWin.visible = !impWin.visible;
                return;
            }

            if (openMenu.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("Menu Button Pressed");
                mainPanel.visible = !mainPanel.visible;

                if (mainPanel.visible)
                {
                    impWin.visible = false;
                    constructionManager.BuildMode = ConstructionManager.BuildingMode.None;
                }
                return;
            }

            if (sortingbatteryPanel.visible)
            {
                if (sortingbatteryButtonUp.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Battery)] = ConstructionManager.BuildingDirection.UP;
                }
                if (sortingbatteryButtonRight.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Battery)] = ConstructionManager.BuildingDirection.RIGHT;
                }
                if (sortingbatteryButtonDown.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Battery)] = ConstructionManager.BuildingDirection.DOWN;
                }

                if (sortingleatherButtonUp.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Leather)] = ConstructionManager.BuildingDirection.UP;
                }
                if (sortingleatherButtonRight.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Leather)] = ConstructionManager.BuildingDirection.RIGHT;
                }
                if (sortingleatherButtonDown.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Leather)] = ConstructionManager.BuildingDirection.DOWN;
                }

                if (sortingplasticButtonUp.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Plastic)] = ConstructionManager.BuildingDirection.UP;
                }
                if (sortingplasticButtonRight.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Plastic)] = ConstructionManager.BuildingDirection.RIGHT;
                }
                if (sortingplasticButtonDown.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    selectedSortingMachine.SortDirection[typeof(Plastic)] = ConstructionManager.BuildingDirection.DOWN;
                }

                if (closeSorting.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    sortingSettings.visible = false;
                    selectedSortingMachine = null;
                }
                #endregion
            }

            if (impWin.visible)
            {
                if (batteryButton.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    if (Battery.BatteryPrice <= StatManager.Instance.GetMoney)
                    {
                        ImportManager.Instance.ImportResourcesQueue.Enqueue(ImportManager.ImportOptions.Battery);
                        StatManager.Instance.RemoveMoney(Battery.BatteryPrice);
                        Debug.WriteLine("Add Battery to Importer");
                    }
                    impWin.visible = false;
                    return;
                }

                if (leatherButton.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    if (Leather.LeatherPrice <= StatManager.Instance.GetMoney)
                    {
                        ImportManager.Instance.ImportResourcesQueue.Enqueue(ImportManager.ImportOptions.Leather);
                        StatManager.Instance.RemoveMoney(Leather.LeatherPrice);
                        Debug.WriteLine("Add Leather to Importer");
                    }
                    impWin.visible = false;
                    return;
                }

                if (plasticButton.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
                {
                    if (Plastic.PlasticPrice <= StatManager.Instance.GetMoney)
                    {
                        ImportManager.Instance.ImportResourcesQueue.Enqueue(ImportManager.ImportOptions.Plastic);
                        StatManager.Instance.RemoveMoney(Plastic.PlasticPrice);
                        Debug.WriteLine("Add Plastic to Importer");
                    }
                    impWin.visible = false;
                    return;
                }
            }
        }
    }
}
