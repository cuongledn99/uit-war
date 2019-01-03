using Facebook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace uit_war
{
    public partial class MainGameForm : Form
    {
        #region Properties
        CurrentItem currentItem;
        int availableMoney;
        int tropPrice = 0;
        //Process p = new Process();
        //public SoundPlayer Mcd = new SoundPlayer("Resources\\background.wav");
        #endregion

        public MainGameForm()
        {
            InitializeComponent();
            //no care
            Control.CheckForIllegalCrossThreadCalls = false;
            availableMoney = 0;

            InitRender();
            InitProperties();
            

            Listen();

        }
        private void InitRender()
        {
            
            Const.graphics = this.CreateGraphics();
            // Tạo back buffer
            Const.backBuffer = new Bitmap(this.ClientSize.Width,
            this.ClientSize.Height);
            // Lấy ảnh sprite
            Const.healingSpell_tip = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\healingSpell_tip.png"));
            Const.knight_tip = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\knight_tip.png"));
            Const.megaman_tip = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\megaman_tip.png"));
            Const.hulk_tip = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_tip.png"));

            Const.sprite_touch = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\touch.png"));
            Image image = Image.FromFile(Application.StartupPath + "\\Resources\\mario_right.png");
            Const.sprite_Mario_Right = new Bitmap(image);
            Const.sprite_Mario_Left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\mario_left.png"));
            Const.sprite_mario_attack_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\mario_attack_left.png"));
            Const.sprite_Mario_Attack_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\mario_attack_right.png"));
            Const.sprite_Tank_Right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_right.png"));
            Const.sprite_tank_attack_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\mario_attack_right.png"));
            Const.sprite_knight_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\knight_left.png"));
            Const.sprite_knight_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\knight_right.png"));
            Const.sprite_knight_attack_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\knight_attack_left.png"));
            Const.sprite_knight_attack_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\knight_attack_right.png"));
            Const.sprite_hulk_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_left.png"));
            Const.sprite_hulk_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_right.png"));
            Const.sprite_hulk_attack_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_attack_left.png"));
            Const.sprite_hulk_attack_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\hulk_attack_right.png"));
            Const.sprite_megaman_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\megaman_left.png"));
            Const.sprite_megaman_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\megaman_right.png"));
            Const.sprite_megaman_attack_left = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\megaman_attack_left.png"));
            Const.sprite_megaman_attack_right = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\megaman_attack_right.png"));
            Const.spriteHP0 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\0.png"));
            Const.spriteHP10 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\10.png"));
            Const.spriteHP20 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\20.png"));
            Const.spriteHP30 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\30.png"));
            Const.spriteHP40 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\40.png"));
            Const.spriteHP50 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\50.jpg"));
            Const.spriteHP60 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\60.png"));
            Const.spriteHP70 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\70.png"));
            Const.spriteHP80 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\80.png"));
            Const.spriteHP90 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\90.jpg"));
            Const.spriteHP100 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\100.png"));
            Const.spriteHP10_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\10_blue.png"));
            Const.spriteHP20_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\20_blue.png"));
            Const.spriteHP30_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\30_blue.png"));
            Const.spriteHP40_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\40_blue.png"));
            Const.spriteHP50_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\50_blue.png"));
            Const.spriteHP60_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\60_blue.png"));
            Const.spriteHP70_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\70_blue.png"));
            Const.spriteHP80_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\80_blue.png"));
            Const.spriteHP90_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\90_blue.png"));
            Const.spriteHP100_blue = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\100_blue.png"));

            Const.spriteMoney0 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney0.png"));
            Const.spriteMoney1 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney1.png"));
            Const.spriteMoney2 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney2.png"));
            Const.spriteMoney3 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney3.png"));
            Const.spriteMoney4 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney4.png"));
            Const.spriteMoney5 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney5.png"));
            Const.spriteMoney6 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney6.png"));
            Const.spriteMoney7 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney7.png"));
            Const.spriteMoney8 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney8.png"));
            Const.spriteMoney9 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney9.png"));
            Const.spriteMoney10 = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteMoney10.png"));
            Const.spriteAvailableMoney = Const.spriteMoney0;
            Const.spriteHealingSpell = new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\spriteHeal.png"));

            Const.spriteBoom= new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\giantboom.png"));
            Const.spriteBoomExloding= new Bitmap(Image.FromFile(Application.StartupPath + "\\Resources\\exploding_effect.png"));
        }
        private void InitProperties()
        {

            Const.listBooms = new List<Boom>();
            Const.listBooms.Clear();
            Const.listSpells = new List<Spell>();
            Const.listSpells.Clear();
            Const.listTrops = new List<Trop>();
            Const.listTrops.Clear();
            Const.spriteAvailableMoney = Const.spriteMoney0;
            //create 6 booms
            Const.listBooms.Add(new Boom(Const.currentTeam, new Point(0, 111+25)));
            Const.listBooms.Add(new Boom(Const.currentTeam, new Point(0, 275+ 25)));
            Const.listBooms.Add(new Boom(Const.currentTeam, new Point(0, 444+ 25)));
            Const.listBooms.Add(new Boom(!Const.currentTeam, new Point(this.ClientSize.Width-110, 111+ 25)));
            Const.listBooms.Add(new Boom(!Const.currentTeam, new Point(this.ClientSize.Width-110, 275+ 25)));
            Const.listBooms.Add(new Boom(!Const.currentTeam, new Point(this.ClientSize.Width-110, 444+ 25)));
        }
        private void UpdateMoney()
        {
            switch (availableMoney)
            {
                case 0:
                    Const.spriteAvailableMoney = Const.spriteMoney0;
                    break;
                case 1:
                    Const.spriteAvailableMoney = Const.spriteMoney1;
                    break;
                case 2:
                    Const.spriteAvailableMoney = Const.spriteMoney2;
                    break;
                case 3:
                    Const.spriteAvailableMoney = Const.spriteMoney3;
                    break;
                case 4:
                    Const.spriteAvailableMoney = Const.spriteMoney4;
                    break;
                case 5:
                    Const.spriteAvailableMoney = Const.spriteMoney5;
                    break;
                case 6:
                    Const.spriteAvailableMoney = Const.spriteMoney6;
                    break;
                case 7:
                    Const.spriteAvailableMoney = Const.spriteMoney7;
                    break;
                case 8:
                    Const.spriteAvailableMoney = Const.spriteMoney8;
                    break;
                case 9:
                    Const.spriteAvailableMoney = Const.spriteMoney9;
                    break;
                case 10:
                    Const.spriteAvailableMoney = Const.spriteMoney10;
                    break;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //drop spell
            if (currentItem == CurrentItem.SpellHeal)
            {
                Spell spell = null;
                switch (currentItem)
                {
                    case CurrentItem.SpellHeal:
                        spell = new Heal(Const.currentTeam);
                        break;
                }
                if (availableMoney >= spell.Price)
                {
                    //decrease available money
                    availableMoney -= spell.Price;
                    UpdateMoney();
                    spell.CurrentLocation = new Point(e.X - 23, e.Y - 23);
                    //send current spell type and its position to rival
                    Program.socket.Send(new SocketData((int)SocketCommand.SEND_POINT, currentItem, spell.CurrentLocation));
                    //add spell to list spell
                    Const.listSpells.Add(spell);
                }
            }
            //drop trop
            else
            {
                //set curren trop type
                Trop trop = null;
                switch (currentItem)
                {
                    case CurrentItem.Knight:
                        trop = new Knight(Const.currentTeam);
                        break;
                    case CurrentItem.Megaman:
                        trop = new Megaman(Const.currentTeam);
                        break;
                    case CurrentItem.Hulk:
                        trop = new Hulk(Const.currentTeam);
                        break;
                }
                //set trop location base on clicked point
                //only allow drop trop at specific location
                //and enough money
                try
                {
                    if (((e.Y >= 124 && e.Y <= 211) || (e.Y >= 307 && e.Y <= 374) || (e.Y >= 476 && e.Y <= 541))
                        && (Const.currentTeam ? e.X < 365 : e.X > 430)
                        && availableMoney >= trop.Price)
                    {
                        //decrease available money
                        availableMoney -= trop.Price;
                        UpdateMoney();
                        //lane 1
                        if (e.Y >= 124 && e.Y <= 211)
                            trop.CurrentLocation = new Point(e.X, 111);
                        //lane 2
                        else if (e.Y >= 307 && e.Y <= 374)
                            trop.CurrentLocation = new Point(e.X, 275);
                        //lane 3
                        else if (e.Y >= 476 && e.Y <= 541)
                            trop.CurrentLocation = new Point(e.X, 444);
                        //send current trop type and its position to rival
                        Program.socket.Send(new SocketData((int)SocketCommand.SEND_POINT, currentItem, trop.CurrentLocation));
                        //add trop to listTrops
                        Const.listTrops.Add(trop);
                    }
                }
                catch { }
                //MessageBox.Show(e.X + "-" + e.Y);
            }
            //MessageBox.Show(e.X + "-" + e.Y);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            SoundPlayer.ChangePlay(Application.StartupPath + "\\Resources\\hit.mp3");
            SoundPlayer.Play();
        }

        Thread listenThread;
         void ListenUntilReceivedData()
        {

            listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)Program.socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {
                    ListenUntilReceivedData();
                }
            });
            listenThread.IsBackground = true;
            try
            {
                listenThread.Start();
            }
            catch { }
            
        }
        void Listen()
        {
            Thread listenThread = new Thread(() =>
            {
                try
                {
                    SocketData data = (SocketData)Program.socket.Receive();

                    ProcessData(data);
                }
                catch (Exception e)
                {

                }
            });
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.START_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        btMegaman.Show();
                        btKnight.Show();
                        btHulk.Show();
                        btHealingSpell.Show();
                        panel1.Show();
                        picboxChatHead.Show();
                        timer1.Start();
                        timer_increase_money.Start();
                        timerFindMatch.Stop();
                        //update isFindingMatch of server to false
                        SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
                        string sql = string.Format("update users set isFindingMatch=0 where id='{0}'", Const.userInfo[0]);
                        conn.AddRemoveAlter(sql);
                        conn.Close();
                    }));
                    break;
                case (int)SocketCommand.NOTIFY:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    break;
                case (int)SocketCommand.SEND_POINT:
                    //use,no care
                    this.Invoke((MethodInvoker)(() =>
                    {
                        if (data.Current == CurrentItem.SpellHeal)
                        {
                            Spell spell = null;
                            switch (data.Current)
                            {
                                case CurrentItem.SpellHeal:
                                    spell = new Heal(!Const.currentTeam);
                                    break;
                            }
                            //set current location of spell received
                            spell.CurrentLocation = data.Point;
                            //add spell to list spell
                            Const.listSpells.Add(spell);
                        }
                        else
                        {
                            Trop trop = null;
                            switch (data.Current)
                            {
                                case CurrentItem.Knight:
                                    trop = new Knight(!Const.currentTeam);
                                    break;
                                case CurrentItem.Megaman:
                                    trop = new Megaman(!Const.currentTeam);
                                    break;
                                case CurrentItem.Hulk:
                                    trop = new Hulk(!Const.currentTeam);
                                    break;
                            }
                            //set current location of trop received
                            trop.CurrentLocation = data.Point;
                            //add trop to list trop
                            Const.listTrops.Add(trop);
                        }
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    break;
                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        timer1.Stop();
                        timer_increase_money.Stop();
                        MessageBox.Show("You lose");
                        this.Close();
                        Program.login.Show();
                    }));
                    break;
                case (int)SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Đối thủ đã thoát");
                        //SocketManager.CloseConnection();
                        this.Close();
                        Program.login.Show();

                        //Program.main = null;
                    }));
                    break;
                case (int)SocketCommand.SEND_MESSAGE:
                    //show message of rival
                    richTextBox1.AppendText("\n\n" + data.Message + "\n\n");
                    int startIndex = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.Lines.Length - 3);
                    int lastIndex = richTextBox1.TextLength - 2;
                    richTextBox1.Select(startIndex, lastIndex);
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.SelectionBackColor = Color.LightGray;
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Arial", 15);
                    richTextBox1.ScrollToCaret();
                    richTextBox1.DeselectAll();
                    break;
                default:
                    break;
            }

            Listen();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Listen();
            try
            {
                //remove trops 
                //reset attacker's index for each trops
                //check win/lose
                for (int i = 0; i < Const.listTrops.Count; i++)
                {

                    //process win/lose
                    //trop outside screen
                    //and trop is my team
                    if (Const.listTrops[i].CurrentLocation.X < 0 || Const.listTrops[i].CurrentLocation.X > this.ClientSize.Width
                        && Const.listTrops[i].CurrentTeam == Const.currentTeam)
                    {
                        timer1.Stop();
                        timer_increase_money.Stop();

                        //notify rival that he was lose
                        Program.socket.Send(new SocketData((int)SocketCommand.END_GAME, currentItem, Point.Empty));
                        //update won_matchs in database
                        SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
                        string sql = "update users set won_matchs+=1 where id='" + Const.userInfo[0] + "'";
                        conn.AddRemoveAlter(sql);
                        conn.Close();
                        MessageBox.Show("You win");
                        this.Close();
                        Program.login.Show();
                    }
                    //remove trops died
                    if (Const.listTrops[i].CurrentHP <= 0)
                    {
                        //set attack status of attackers that are attacking this to false
                        foreach (int attackerIndex in Const.listTrops[i].BeingAttackedBy)
                        {
                            Const.listTrops[attackerIndex].CurrentStatus = false;
                        }
                        //remove trops
                        Const.listTrops.RemoveAt(i);
                    }
                    //reset attacker's index for each trops
                    Const.listTrops[i].BeingAttackedBy.Clear();
                }
                //check and set attack status for trops
                if (Const.listTrops.Count == 1)
                    Const.listTrops[0].CurrentStatus = false;
                for (int i = 0; i < Const.listTrops.Count - 1; i++)
                    for (int j = i + 1; j < Const.listTrops.Count; j++)
                        // 2 trops are rival and in the same lane
                        if (Const.listTrops[i].CurrentTeam != Const.listTrops[j].CurrentTeam
                            && Const.listTrops[i].CurrentLocation.Y == Const.listTrops[j].CurrentLocation.Y)
                            // trops[i] is left team
                            //trops[j] is right team
                            if (Const.listTrops[i].CurrentTeam)
                            {
                                //trops[i] is ready to attack
                                if (Const.listTrops[i].CurrentLocation.X + Const.listTrops[i].Sprite.Width / 3 + Const.listTrops[i].AttackRange >= Const.listTrops[j].CurrentLocation.X)
                                {
                                    Const.listTrops[i].CurrentStatus = true;//attack
                                    Const.listTrops[i].CurrentVictim = j;//set victim index
                                    Const.listTrops[j].BeingAttackedBy.Add(i);//store attacker's index to set attacker status to running after die
                                }

                                //trops[j] is reader to attack
                                if (Const.listTrops[j].CurrentLocation.X - Const.listTrops[j].AttackRange <= Const.listTrops[i].CurrentLocation.X + Const.listTrops[i].Sprite.Width / 3)
                                {
                                    Const.listTrops[j].CurrentStatus = true;//attack
                                    Const.listTrops[j].CurrentVictim = i;//set victim index
                                    Const.listTrops[i].BeingAttackedBy.Add(j);//store attacker's index to set attacker status to running after die
                                }
                            }
                            //trops[i] is right team
                            //trops[j] is left team
                            else
                            {
                                //trops[j] is ready to attack
                                if (Const.listTrops[j].CurrentLocation.X + Const.listTrops[j].Sprite.Width / 3 + Const.listTrops[j].AttackRange >= Const.listTrops[i].CurrentLocation.X)
                                {
                                    Const.listTrops[j].CurrentStatus = true;//attack
                                    Const.listTrops[j].CurrentVictim = i;//set victim index
                                    Const.listTrops[i].BeingAttackedBy.Add(j);//store attacker's index to set attacker status to running after die
                                }
                                //trops[i] is reader to attack
                                if (Const.listTrops[i].CurrentLocation.X - Const.listTrops[i].AttackRange <= Const.listTrops[j].CurrentLocation.X + Const.listTrops[j].Sprite.Width / 3)
                                {
                                    Const.listTrops[i].CurrentStatus = true;//attack
                                    Const.listTrops[i].CurrentVictim = j;//set victim index
                                    Const.listTrops[j].BeingAttackedBy.Add(i);//store attacker's index to set attacker status to running after die
                                }
                            }
                //check trops in the affect range of spells
                for (int i = 0; i < Const.listTrops.Count; i++)
                    for (int j = 0; j < Const.listSpells.Count; j++)
                        // trops in affect range of spell
                        if (Const.listSpells[j].CurrentLocation.X + Const.listSpells[j].Sprite.Width / 3 >= Const.listTrops[i].CurrentLocation.X
                            && Const.listSpells[j].CurrentLocation.X <= Const.listTrops[i].CurrentLocation.X + Const.listTrops[i].Sprite.Width / 3
                            && Const.listSpells[j].CurrentLocation.Y <= Const.listTrops[i].CurrentLocation.Y + Const.listTrops[i].Sprite.Height / 4
                            && Const.listSpells[j].CurrentLocation.Y + Const.listSpells[j].Sprite.Height / 4 >= Const.listTrops[i].CurrentLocation.Y)
                        {
                            //add
                            Const.listSpells[j].AffectedTrops.Add(i);

                        }
                //check trops in range of boom
                for (int i = 0; i < Const.listTrops.Count; i++)
                    for (int j = 0; j < Const.listBooms.Count; j++)
                        // trops in affect range of boom
                        if (Const.listBooms[j].CurrentLocation.X + Const.listBooms[j].Sprite.Width / 3 >= Const.listTrops[i].CurrentLocation.X
                            && Const.listBooms[j].CurrentLocation.X <= Const.listTrops[i].CurrentLocation.X + Const.listTrops[i].Sprite.Width / 3
                            && Const.listBooms[j].CurrentLocation.Y <= Const.listTrops[i].CurrentLocation.Y + Const.listTrops[i].Sprite.Height / 4
                            && Const.listBooms[j].CurrentLocation.Y + Const.listBooms[j].Sprite.Height / 4 >= Const.listTrops[i].CurrentLocation.Y)
                        {
                            //add
                            Const.listBooms[j].AffectedTrops.Add(i);

                        }
                //make spell affect on trops
                for (int i = 0; i < Const.listSpells.Count; i++)
                    Const.listSpells[i].Drop();
                //make boom explode
                for (int i = 0; i < Const.listBooms.Count; i++)
                    Const.listBooms[i].Explode();
                //set trops running or attacking base on its status
                for (int i = 0; i < Const.listTrops.Count; i++)
                {

                    //running
                    if (!Const.listTrops[i].CurrentStatus)
                        Const.listTrops[i].Move();
                    //attacking
                    else if (Const.listTrops[i].CurrentStatus)
                        Const.listTrops[i].Attack();
                }

                //render all
                RenderTool.Render();
            }
            catch { }

        }

        //button knight
        private void button_minion_clicked(object sender, EventArgs e)
        {
            tropPrice = 1;
            currentItem = CurrentItem.Knight;
        }

        //button megaman
        private void button_archer_clicked(object sender, EventArgs e)
        {
            tropPrice = 2;
            currentItem = CurrentItem.Megaman;
        }

        //button hulk
        private void button_giant_clicked(object sender, EventArgs e)
        {
            tropPrice = 3;
            currentItem = CurrentItem.Hulk;
        }

        private void btHealingSpell_Click(object sender, EventArgs e)
        {
            currentItem = CurrentItem.SpellHeal;
        }

        private void MainGameForm_Shown(object sender, EventArgs e)
        {
            RenderTool.Render();
            //if client--> run
            //send start signal to server
            if (!Program.socket.isServer)
            {
                //update isFinding match to false
                SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
                string sql = string.Format("update users set isFindingMatch=0 where id='{0}'", Const.userInfo[0]);
                conn.AddRemoveAlter(sql);
                conn.Close();
                //
                Program.socket.Send(new SocketData((int)SocketCommand.START_GAME, currentItem, Point.Empty));
                timer1.Start();
                timer_increase_money.Start();
            }
            //if server-->wait for client
            else
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\wait.jpg");
                btHealingSpell.Hide();
                btKnight.Hide();
                btMegaman.Hide();
                btHulk.Hide();
                panel1.Hide();
                picboxChatHead.Hide();
                Const.startTime = DateTime.Now.TimeOfDay;
                ListenUntilReceivedData();
                timerFindMatch = new Timer();
                timerFindMatch.Tick += TimerFindMatch_Tick;
                timerFindMatch.Start();

            }
        }
        // cancel find match after 20s not found
        Timer timerFindMatch;
        bool isCalledListenUntilReceivedData = false;
        private void TimerFindMatch_Tick(object sender, EventArgs e)
        {
            //call ListenUntilReceivedData() if not called yet
            //if (!isCalledListenUntilReceivedData)
            //{
            //    ListenUntilReceivedData();
            //    isCalledListenUntilReceivedData = true;
            //}
            if ((DateTime.Now.TimeOfDay - Const.startTime).Seconds > 20)
            {
                timerFindMatch.Stop();
                listenThread.Abort();
                MessageBox.Show("Không tìm thấy trận");
                
                this.Close();
            }
            
        }

        private void UpdateButtonEffect()
        {
            if (availableMoney >= 7)
                btHealingSpell.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\healing_spell.png");
            else
                btHealingSpell.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\healing_spell_faded.jpg");
            if (availableMoney >= 4)
                btKnight.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\knight.jpg");
            else
                btKnight.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\knight_faded.jpg");
            if (availableMoney >= 6)
            {
                btHulk.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\hulk.jpg");
                btMegaman.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\megaman.png");
            }
            else
            {
                btHulk.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\hulk_faded.jpg");
                btMegaman.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Resources\\megaman_faded.jpg");
            }
        }
        //increase money after 2s
        private void timer_inc_money_tick(object sender, EventArgs e)
        {
            if (availableMoney < 10)
            {
                availableMoney += 1;
            }
            UpdateMoney();
            UpdateButtonEffect();
            //remove spell when out of affect time
            for (int i = 0; i < Const.listSpells.Count; i++)
                if (Const.listSpells[i].AvailableTime < 0)
                    Const.listSpells.RemoveAt(i);
            for (int i = 0; i < Const.listSpells.Count; i++)
                Const.listSpells[i].AvailableTime -= 2;
            //remove booms exploded
            for (int i = 0; i < Const.listBooms.Count; i++)
            {
                if (Const.listBooms[i].IsExploded)
                {
                    Const.listBooms.RemoveAt(i);
                }
            }
        }
        PictureBox pictureBox = new PictureBox();
        private void btHealingSpell_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Size = Const.healingSpell_tip.Size;
            pictureBox.Image = Const.healingSpell_tip;
            pictureBox.Location = new Point(btHealingSpell.Location.X, btHealingSpell.Location.Y + btHealingSpell.Height);
            this.Controls.Add(pictureBox);
        }

        private void btHealingSpell_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(pictureBox);
        }

        private void btKnight_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Size = Const.knight_tip.Size;
            pictureBox.Image = Const.knight_tip;
            pictureBox.Location = new Point(btKnight.Location.X, btKnight.Location.Y + btKnight.Height);
            this.Controls.Add(pictureBox);
        }

        private void btKnight_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(pictureBox);
        }

        private void btMegaman_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Size = Const.megaman_tip.Size;
            pictureBox.Image = Const.megaman_tip;
            pictureBox.Location = new Point(btMegaman.Location.X, btMegaman.Location.Y + btMegaman.Height);
            this.Controls.Add(pictureBox);
        }

        private void btMegaman_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(pictureBox);
        }

        private void btHulk_MouseHover(object sender, EventArgs e)
        {
            pictureBox.Size = Const.hulk_tip.Size;
            pictureBox.Image = Const.hulk_tip;
            pictureBox.Location = new Point(btHulk.Location.X, btHulk.Location.Y + btHulk.Height);
            this.Controls.Add(pictureBox);
        }

        private void btHulk_MouseLeave(object sender, EventArgs e)
        {
            this.Controls.Remove(pictureBox);
        }

        private void MainGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                //notify rival
                try
                {
                    Program.socket.Send(new SocketData((int)SocketCommand.QUIT, CurrentItem.Hulk, Point.Empty));
                }
                catch { }
                //return homepage
                Program.login.Show();
                //update is finding match to false if user cancel finding match
                SQLConnection conn = new SQLConnection(SQLConnection.GetDatabasePath(Const.serverIP + ",6969", "doan", "admin", "cuong123"));
                string sql = string.Format("update users set isFindingMatch=0 where id='{0}'", Const.userInfo[0]);
                conn.AddRemoveAlter(sql);
                conn.Close();
            }
        }

        private void MainGameForm_Activated(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = Application.StartupPath + "\\Resources\\hit.mp3";
            axWindowsMediaPlayer2.URL = Application.StartupPath + "\\Resources\\background.wav";
            axWindowsMediaPlayer2.settings.volume = 7;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.settings.volume = 30;
            axWindowsMediaPlayer2.settings.autoStart = true;
            axWindowsMediaPlayer2.settings.setMode("loop", true);
        }

        private void MainGameForm_Deactivate(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer2.Ctlcontrols.stop();

        }
        int rows = 0;
        private void btSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }
        private void SendMessage()
        {
            //show message on chat box
            richTextBox1.AppendText("\n\n" + txtboxChat.Text + "\n\n");

            int startIndex = richTextBox1.GetFirstCharIndexFromLine(richTextBox1.Lines.Length - 3);
            int lastIndex = richTextBox1.TextLength - 2;
            richTextBox1.Select(startIndex, lastIndex);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            richTextBox1.SelectionBackColor = Color.Blue;
            richTextBox1.SelectionColor = Color.White;
            richTextBox1.SelectionFont = new Font("Arial", 15);
            richTextBox1.ScrollToCaret();
            //send message to rival
            Program.socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, txtboxChat.Text));
            txtboxChat.Clear();
            richTextBox1.DeselectAll();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //send message if
            //press enter
            //chat box is opening
            //textbox not empty and focused
            //if (e.KeyCode == Keys.A && Const.currentChatBoxStatus && txtboxChat.Focused && txtboxChat.Text != "")
            //    SendMessage();
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void picboxChatHead_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(picboxChatHead, "Bấm để đóng/mở");
        }

        private void picboxChatHead_Click(object sender, EventArgs e)
        {
            Const.currentChatBoxStatus = !Const.currentChatBoxStatus;
            //show chat box
            if (Const.currentChatBoxStatus)
            {
                picboxChatHead.Location = new Point(0, panel1.Location.Y - picboxChatHead.Height);
                panel1.Show();
            }
            //hide chat box
            else
            {
                picboxChatHead.Location = new Point(0, this.ClientSize.Height - picboxChatHead.Height);
                panel1.Hide();
            }

        }

        private void txtboxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtboxChat.Text != "")
                SendMessage();
        }
    }
}