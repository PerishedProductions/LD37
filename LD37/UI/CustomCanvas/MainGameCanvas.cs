using LD37.GameLevels;
using LD37.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LD37.UI
{
    class MainGameCanvas : UICanvas
    {

        public ConstructionManager constructionManager;

        public bool isBuilding = false;

        UIText money;
        UIText buildMode;
        UIText buildRotation;

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
        UIPanel resWin;

        UIText impTitle;
        UIText resTitle;

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

        int resWindowW = 1000;
        int resWindowH = 600;

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

        public override void LoadContent(ContentManager content)
        {
            base.LoadContent(content);

            money = (UIText)CreateUIElement(new UIText(new Vector2(padding, 0), "Money: $1 000 000"));
            buildMode = (UIText)CreateUIElement(new UIText(new Vector2(padding, 30), "Build Mode: "));
            buildRotation = (UIText)CreateUIElement(new UIText(new Vector2(padding, 60), "Build Rotation: "));

            openMenu = (UIButton)CreateUIElement(new UIButton("Menu", new Rectangle(windowWidth - menuBtnW, windowHeight - menuBtnH, menuBtnW, menuBtnH), new Vector2(10, 5)));
            mainPanel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(0, windowHeight - menuBtnH, windowWidth - menuBtnW, menuBtnH)));
            mainPanel.visible = false;

            imp = (UIButton)mainPanel.CreateUIElement(new UIButton("Import Elf", new Rectangle(0 + padding, windowHeight - impH, impW, impH), new Vector2(10, 5), WindowTheme.Light));
            enterBuildMode = (UIButton)mainPanel.CreateUIElement(new UIButton("Build Mode", new Rectangle(impW + padding * 2, windowHeight - resH, resW, resH), new Vector2(10, 5), WindowTheme.Light));

            impWin = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - impWindowW / 2, windowHeight / 2 - impWindowH / 2, impWindowW, impWindowH)));
            impWin.visible = false;
            impTitle = (UIText)impWin.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + padding), "Import Elf Department"));

            resWin = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - resWindowW / 2, windowHeight / 2 - resWindowH / 2, resWindowW, resWindowH)));
            resWin.visible = false;
            resTitle = (UIText)resWin.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + padding), "Research Elf Department"));

            buildPanel = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(0, windowHeight - menuBtnH, windowWidth - menuBtnW, menuBtnH)));
            buildPanel.visible = false;

            exitBuildMode = (UIButton)buildPanel.CreateUIElement(new UIButton("Exit Build Mode", new Rectangle(0 + padding, windowHeight - exitBuildH, exitBuildW, exitBuildH), new Vector2(10, 5), WindowTheme.Light));
            sellMachine = (UIButton)buildPanel.CreateUIElement(new UIButton("Sell Machine", new Rectangle(exitBuildW + padding * 2, windowHeight - sellH, sellW, sellH), new Vector2(10, 5), WindowTheme.Light));

            machinePanel = (UIPanel)buildPanel.CreateUIElement(new UIPanel(new Rectangle(windowWidth - machinePanelW - menuBtnW - padding, windowHeight - machinePanelH - 50, machinePanelW, machinePanelH), WindowTheme.Light));

            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Air Pump", new Rectangle(windowWidth - menuBtnW - machine0W - padding * 2, windowHeight - machine0H - 50, machine0W, machine0H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Assembler", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - padding * 3, windowHeight - machine1H - 50, machine1W, machine1H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Transporter Belt", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - padding * 4, windowHeight - machine2H - 50, machine2W, machine2H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Sorting Machine", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - machine3W - padding * 5, windowHeight - machine3H - 50, machine3W, machine3H), new Vector2(10, 0), WindowTheme.Dark)));
        }

        public override void Update(GameTime gameTime)
        {
            money.text = "Money:  $" + StatManager.Instance.GetMoney;
            buildMode.text = "Build Tool: " + constructionManager.BuildMode;
            buildRotation.text = "Build Direction: " + constructionManager.BuildDirection;

            imp.Update(gameTime);
            enterBuildMode.Update(gameTime);
            exitBuildMode.Update(gameTime);
            sellMachine.Update(gameTime);

            for (int i = 0; i < machines.Count; i++)
            {
                machines[i].Update(gameTime);
            }

            if (machines[0].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.AirPump;
                mainPanel.visible = false;
            }

            if (machines[1].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.Assembler;
                mainPanel.visible = false;
            }

            if (machines[2].mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                constructionManager.BuildMode = ConstructionManager.BuildingMode.TransportBelt;
                mainPanel.visible = false;
            }

            if (imp.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                impWin.visible = true;
                resWin.visible = false;
            }

            if (enterBuildMode.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                mainPanel.visible = false;
                buildPanel.visible = true;
                isBuilding = true;
            }

            if (exitBuildMode.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                if (isBuilding)
                {
                    Debug.WriteLine("ButtonPressed");
                    mainPanel.visible = true;
                    buildPanel.visible = false;
                    isBuilding = false;
                }
            }

            if (openMenu.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                if (!isBuilding)
                {
                    mainPanel.visible = !mainPanel.visible;

                    if (mainPanel.visible)
                    {
                        impWin.visible = false;
                        resWin.visible = false;

                        constructionManager.BuildMode = ConstructionManager.BuildingMode.None;
                    }
                }
            }

            base.Update(gameTime);
        }
    }
}
