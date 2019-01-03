using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uit_war
{
    abstract class Spell
    {
        private int price;
        private bool currentTeam;// true: left team|| false: right team
        private Point currentLocation;
        private Bitmap sprite;
        private int availableTime;
        private List<int> affectedTrops;//store index of affected trops
        public int Price { get => price; set => price = value; }
        public bool CurrentTeam { get => currentTeam; set => currentTeam = value; }
        public Point CurrentLocation { get => currentLocation; set => currentLocation = value; }
        public Bitmap Sprite { get => sprite; set => sprite = value; }
        public int AvailableTime { get => availableTime; set => availableTime = value; }
        public List<int> AffectedTrops { get => affectedTrops; set => affectedTrops = value; }

        public abstract void Drop();

    }
    class Heal : Spell
    {
        public Heal(bool currentTeam)
        {
            AvailableTime = 6;
            CurrentTeam = currentTeam;
            Price = 7;
            Sprite = Const.spriteHealingSpell;
            AffectedTrops = new List<int>();
        }
        public override void Drop()
        {
            //increase trop's HP if trop and spell are in the same team
            foreach (int index in AffectedTrops)
            {
                if (Const.listTrops[index].CurrentTeam==CurrentTeam && Const.listTrops[index].CurrentHP + 5 <= Const.listTrops[index].HP)
                    Const.listTrops[index].CurrentHP += 5;
            }
            AffectedTrops.Clear();
        }
    }
    
    class Freze : Spell
    {
        public Freze(bool currentTeam)
        {
            CurrentTeam = currentTeam;
        }
        public override void Drop()
        {
            throw new NotImplementedException();
        }
    }
    class Boom
    {
        private bool isExploded;
        private bool currentTeam;// true: left team|| false: right team
        private Point currentLocation;
        private Bitmap sprite;
        private int availableTime;
        private List<int> affectedTrops;//store index of affected trops
        public bool CurrentTeam { get => currentTeam; set => currentTeam = value; }
        public Point CurrentLocation { get => currentLocation; set => currentLocation = value; }
        public Bitmap Sprite { get => sprite; set => sprite = value; }
        public List<int> AffectedTrops { get => affectedTrops; set => affectedTrops = value; }
        public bool IsExploded { get => isExploded; set => isExploded = value; }
        public Boom(bool currentTeam,Point currentLocation)
        {
            IsExploded = false;
            Sprite = Const.spriteBoom;
            //Sprite.MakeTransparent();
            CurrentTeam = currentTeam;
            CurrentLocation = currentLocation;
            AffectedTrops = new List<int>();
        }
        public void Explode()
        {
            //exlode
           
            //Sprite.MakeTransparent();
            //kill rival trops in range of boom
            foreach (int index in AffectedTrops)
            {
                if (Const.listTrops[index].CurrentTeam != CurrentTeam)
                {
                    //Sprite = Const.spriteBoomExloding;
                    Const.listTrops.RemoveAt(index);
                    IsExploded = true;
                }
            }
            if(isExploded)
            {
                SoundPlayer.ChangePlay(Application.StartupPath + "\\Resources\\explodesound.mp3");
                SoundPlayer.Play();
                Sprite = Const.spriteBoomExloding;
            }
        }
    }
}
