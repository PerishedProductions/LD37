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

        UIText money;
        UIText buildMode;
        UIText buildRotation;

        UIButton openMenu;
        UIPanel mainPanel;
        UIPanel machinePanel;

        List<UIButton> machines = new List<UIButton>();

        UIButton imp;
        UIButton res;

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

        int resW = 155;
        int resH = 50;

        int impWindowW = 1000;
        int impWindowH = 600;

        int resWindowW = 1000;
        int resWindowH = 600;

        int machinePanelW = 650;
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
            //res = (UIButton)mainPanel.CreateUIElement(new UIButton("Research", new Rectangle(impW + padding * 2, windowHeight - resH, resW, resH), new Vector2(10, 5), WindowTheme.Light));

            impWin = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - impWindowW / 2, windowHeight / 2 - impWindowH / 2, impWindowW, impWindowH)));
            impWin.visible = false;
            impTitle = (UIText)impWin.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + padding), "Import Elf Department"));

            resWin = (UIPanel)CreateUIElement(new UIPanel(new Rectangle(windowWidth / 2 - resWindowW / 2, windowHeight / 2 - resWindowH / 2, resWindowW, resWindowH)));
            resWin.visible = false;
            resTitle = (UIText)resWin.CreateUIElement(new UIText(new Vector2(impWin.size.X + impWindowW / 2 - 350 / 2, impWin.size.Y + padding), "Research Elf Department"));

            machinePanel = (UIPanel)mainPanel.CreateUIElement(new UIPanel(new Rectangle(windowWidth - machinePanelW - menuBtnW - padding, windowHeight - machinePanelH, machinePanelW, machinePanelH), WindowTheme.Light));

            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Air Pump", new Rectangle(windowWidth - menuBtnW - machine0W - padding * 2, windowHeight - machine0H, machine0W, machine0H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Assembler", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - padding * 2, windowHeight - machine1H, machine1W, machine1H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Transporter Belt", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - padding * 3, windowHeight - machine2H, machine2W, machine2H), new Vector2(10, 0), WindowTheme.Dark)));
            machines.Add((UIButton)machinePanel.CreateUIElement(new UIButton("Sorting Machine", new Rectangle(windowWidth - menuBtnW - machine0W - machine1W - machine2W - machine3W - padding * 3, windowHeight - machine3H, machine3W, machine3H), new Vector2(10, 0), WindowTheme.Dark)));
        }

        public override void Update(GameTime gameTime)
        {
            money.text = "Money:  $" + StatManager.Instance.GetMoney;
            buildMode.text = "Build Mode: " + constructionManager.BuildMode;
            buildRotation.text = "Build Direction: " + constructionManager.BuildDirection;

            imp.Update(gameTime);
            //res.Update(gameTime);

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

            /*if (res.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                impWin.visible = false;
                resWin.visible = true;
            }*/

            if (openMenu.mouseOver && InputManager.Instance.mouseIsPressed(MouseButton.Left))
            {
                Debug.WriteLine("ButtonPressed");
                mainPanel.visible = !mainPanel.visible;

                if (mainPanel.visible)
                {
                    impWin.visible = false;
                    resWin.visible = false;

                    constructionManager.BuildMode = ConstructionManager.BuildingMode.None;
                }
            }

            base.Update(gameTime);
        }
    }
}
