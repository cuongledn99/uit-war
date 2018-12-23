using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{
    public abstract class Trop
    {
        public Trop()
        {
            CurrentStatus = false;
            BeingAttackedBy = new List<int>();
        }
        private bool currentStatus;// false: running true: attacking
        protected int speed;
        private int damage;
        private float hP;
        private float currentHP;
        private int attackRange;
        private int price;
        private List<int> beingAttackedBy;// store index of attackers
        private PictureBox picture;
        private Bitmap sprite;
        private Bitmap spriteHP;
        private Point currentHPLocation;
        private Point currentLocation;
        private int currentVictim;//store victim index to attack
        public PictureBox Picture { get => picture; set => picture = value; }
        public Bitmap Sprite { get => sprite; set => sprite = value; }
        public Point CurrentLocation { get => currentLocation; set => currentLocation = value; }
        public bool CurrentTeam { get => currentTeam; set => currentTeam = value; }
        public bool CurrentStatus { get => currentStatus; set => currentStatus = value; }
        public int AttackRange { get => attackRange; set => attackRange = value; }
        public Bitmap SpriteHP { get => spriteHP; set => spriteHP = value; }
        public Point CurrentHPLocation { get => currentHPLocation; set => currentHPLocation = value; }
        public float CurrentHP { get => currentHP; set => currentHP = value; }
        public int Damage { get => damage; set => damage = value; }
        public List<int> BeingAttackedBy { get => beingAttackedBy; set => beingAttackedBy = value; }
        public int Price { get => price; set => price = value; }
        public float HP { get => hP; set => hP = value; }
        public int CurrentVictim { get => currentVictim; set => currentVictim = value; }

        private bool currentTeam;//true: left team  false: right team
        public abstract void Move();
        public abstract void Attack();
        public void UpdateHP()
        {
            if (CurrentTeam)//left team
            {
                if (CurrentHP <= 0)
                    SpriteHP = Const.spriteHP0;
                else if (CurrentHP > 0 && CurrentHP <= HP / 100 * 10)// <10%
                    spriteHP = Const.spriteHP10;
                else if (CurrentHP >= HP / 100 * 10 && CurrentHP <= HP / 100 * 20) // <20%
                    spriteHP = Const.spriteHP20;
                else if (CurrentHP >= HP / 100 * 20 && CurrentHP <= HP / 100 * 30)
                    spriteHP = Const.spriteHP30;
                else if (CurrentHP >= HP / 100 * 30 && CurrentHP <= HP / 100 * 40)
                    spriteHP = Const.spriteHP40;
                else if (CurrentHP >= HP / 100 * 40 && CurrentHP <= HP / 100 * 50)
                    SpriteHP = Const.spriteHP50;
                else if (CurrentHP >= HP / 100 * 50 && CurrentHP <= HP / 100 * 60)
                    spriteHP = Const.spriteHP60;
                else if (CurrentHP >= HP / 100 * 60 && CurrentHP <= HP / 100 * 70)
                    spriteHP = Const.spriteHP70;
                else if (CurrentHP >= HP / 100 * 70 && CurrentHP <= HP / 100 * 80)
                    spriteHP = Const.spriteHP80;
                else if (CurrentHP >= HP / 100 * 80 && CurrentHP <= HP / 100 * 90)
                    spriteHP = Const.spriteHP90;
                else if (CurrentHP >= HP / 100 * 90 && CurrentHP <= HP / 100 * 100)
                    spriteHP = Const.spriteHP100;
            }
            else//right team
            {
                if (CurrentHP <= 0)
                    SpriteHP = Const.spriteHP0;
                else if (CurrentHP > 0 && CurrentHP <= HP / 100 * 10)// <10%
                    spriteHP = Const.spriteHP10_blue;
                else if (CurrentHP >= HP / 100 * 10 && CurrentHP <= HP / 100 * 20) // <20%
                    spriteHP = Const.spriteHP20_blue;
                else if (CurrentHP >= HP / 100 * 20 && CurrentHP <= HP / 100 * 30)
                    spriteHP = Const.spriteHP30_blue;
                else if (CurrentHP >= HP / 100 * 30 && CurrentHP <= HP / 100 * 40)
                    spriteHP = Const.spriteHP40_blue;
                else if (CurrentHP >= HP / 100 * 40 && CurrentHP <= HP / 100 * 50)
                    SpriteHP = Const.spriteHP50_blue;
                else if (CurrentHP >= HP / 100 * 50 && CurrentHP <= HP / 100 * 60)
                    spriteHP = Const.spriteHP60_blue;
                else if (CurrentHP >= HP / 100 * 60 && CurrentHP <= HP / 100 * 70)
                    spriteHP = Const.spriteHP70_blue;
                else if (CurrentHP >= HP / 100 * 70 && CurrentHP <= HP / 100 * 80)
                    spriteHP = Const.spriteHP80_blue;
                else if (CurrentHP >= HP / 100 * 80 && CurrentHP <= HP / 100 * 90)
                    spriteHP = Const.spriteHP90_blue;
                else if (CurrentHP >= HP / 100 * 90 && CurrentHP <= HP / 100 * 100)
                    spriteHP = Const.spriteHP100_blue;
            }
        }
        public bool isBeingAttackedBy(int attackerIndex)
        {
            foreach (int i in BeingAttackedBy)
                if (attackerIndex == i)
                    return true;
            return false;
        }
    }
    public class Knight:Trop
    {
        public Knight(bool currentTeam)
        {
            Price = 4;
            CurrentTeam = currentTeam;
            speed = 3;
            Damage = 3;
            HP = 300;
            CurrentHP = HP;
            AttackRange = 1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_knight_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_knight_left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_knight_right;
                Sprite.MakeTransparent();
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_knight_left;
                Sprite.MakeTransparent();
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            //set suitable sprite
            if (CurrentTeam)//team left
            {
                Sprite = Const.sprite_knight_attack_right;
                Sprite.MakeTransparent();
            }
            else if (CurrentTeam == false)//team right
            {
                Sprite = Const.sprite_knight_attack_left;
                Sprite.MakeTransparent();
            }
            //decrease victim's HP
            Const.listTrops[CurrentVictim].CurrentHP -= Damage;
        }
    }
    public class Hulk:Trop
    {
        public Hulk(bool currentTeam)
        {
            Price = 6;
            CurrentTeam = currentTeam;
            speed = 1;
            Damage = 1;
            HP = 600;
            CurrentHP = HP;
            AttackRange = 1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_hulk_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_hulk_left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_hulk_right;
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_hulk_left;
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            //set suitable sprite
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//team left
            {
                Sprite = Const.sprite_hulk_attack_right;
                Sprite.MakeTransparent();
            }
            else if (CurrentTeam == false)//team right
            {
                Sprite = Const.sprite_hulk_attack_left;
                Sprite.MakeTransparent();
            }
            //decrease victim's HP
            Const.listTrops[CurrentVictim].CurrentHP -= Damage;
        }
    }
    public class Megaman:Trop
    {
        public Megaman(bool currentTeam)
        {
            Price = 6;
            CurrentTeam = currentTeam;
            speed = 5;
            Damage = 5;
            HP = 60;
            CurrentHP = HP;
            AttackRange = 100;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_megaman_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_megaman_left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_megaman_right;
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_megaman_left;
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            //set suitable sprite
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Attack_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_mario_attack_left;
            //decrease victim's HP
            Const.listTrops[CurrentVictim].CurrentHP -= Damage;
        }
    }
    public class Archer : Trop
    {
        public Archer(bool currentTeam)
        {
            Price = 4;
            CurrentTeam = currentTeam;
            speed = 3;
            Damage = 2;
            HP = 100;
            CurrentHP = HP;
            AttackRange = 1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_Mario_Left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_Mario_Right;
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_Mario_Left;
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Attack_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_mario_attack_left;
        }
    }
    public class Tank : Trop
    {
        public Tank(bool currentTeam)
        {
            Price = 4;
            CurrentTeam = currentTeam;
            speed = 3;
            Damage = 2;
            HP = 100;
            CurrentHP = HP;
            AttackRange = 1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_Mario_Left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_Tank_Right;
               // Sprite.MakeTransparent();
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_Mario_Left;
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//team left
            {
                Sprite = Const.sprite_tank_attack_right;
                Sprite.MakeTransparent();
            }
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_mario_attack_left;
        }
    }
    public class Minion : Trop
    {
        public Minion(bool currentTeam)
        {
            Price = 3;
            CurrentTeam = currentTeam;
            speed = 3;
            Damage = 2;
            HP = 100;
            CurrentHP = HP;
            AttackRange = 1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_Mario_Left;
        }
        public override void Move()
        {

            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//left team
            {
                Sprite = Const.sprite_Mario_Right;
                CurrentLocation = new Point(CurrentLocation.X + speed, CurrentLocation.Y);
            }
            else if (!CurrentTeam)//right team
            {
                Sprite = Const.sprite_Mario_Left;
                CurrentLocation = new Point(CurrentLocation.X - speed, CurrentLocation.Y);
            }
        }
        public override void Attack()
        {
            UpdateHP();
            CurrentHPLocation = new Point(CurrentLocation.X, CurrentLocation.Y - 3);
            if (CurrentTeam)//team left
                Sprite = Const.sprite_Mario_Attack_right;
            else if (CurrentTeam == false)//team right
                Sprite = Const.sprite_mario_attack_left;
        }
    }
    public enum CurrentItem
    {
        Archer,
        Tank,
        Minion,
        SpellHeal,
        Hulk,
        Megaman,
        Knight
    }
}
