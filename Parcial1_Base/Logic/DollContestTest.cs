using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Parcial1_Base.Logic.Dress;

namespace Parcial1_Base.Logic.Tests
{
    [TestClass()]
    public class DollContestTest
    {
        #region JURY

        private PageantJury jury = new PageantJury();

        #endregion JURY

        #region DOLLS

        private Doll dorothy = new Doll("Dorothy");
        private Doll anastasia = new Doll("Anastasia");
        private Doll nataliya = new Doll("Nataliya");
        private Doll belle = new Doll("Belle");
        private Doll claire = new Doll("Claire");

        #endregion DOLLS

        #region DRESSES

        private Dress blackOfficeSuit = new Dress(5, EColor.Black, EDressCategory.Suit);
        private Dress cheapBlackOfficeSuit = new Dress(3, EColor.Black, EDressCategory.Suit);
        private Dress redOfficeSuit = new Dress(2, EColor.Red, EDressCategory.Suit);

        private Dress redPartyDress = new Dress(4, EColor.Red, EDressCategory.Party);
        private Dress pinkPartyDress = new Dress(4, EColor.Pink, EDressCategory.Party);
        private Dress greenPartyDress = new Dress(6, EColor.Green, EDressCategory.Party);

        private Dress blueCasualDress = new Dress(2, EColor.Blue, EDressCategory.Casual);
        private Dress whiteCasualDress = new Dress(1, EColor.White, EDressCategory.Casual);
        private Dress yellowCasualDress = new Dress(4, EColor.Yellow, EDressCategory.Casual);

        #endregion DRESSES

        #region PURSES

        private Purse cheapPurseA = new Purse(2);
        private Purse cheapPurseB = new Purse(1);
        private Purse midPurse = new Purse(3);
        private Purse premiumPurse = new Purse(4);

        #endregion PURSES

        #region NECKLACES

        private Necklace fantasyNecklaceA = new Necklace(3);
        private Necklace fantasyNecklaceB = new Necklace(1);
        private Necklace silverNecklace = new Necklace(4);
        private Necklace diamondNecklace = new Necklace(7);

        #endregion NECKLACES

        #region BRACELETS

        private Bracelet fantasyBraceletA = new Bracelet(2);
        private Bracelet fantasyBraceletB = new Bracelet(1);
        private Bracelet braidedBracelet = new Bracelet(2);
        private Bracelet whiteGoldBracelet = new Bracelet(4);
        private Bracelet diamondBracelet = new Bracelet(5);

        #endregion BRACELETS

        #region DOLL_METHODS

        [TestMethod()]
        public void CanParticipateTest()
        {
            Doll cloneDorothy = dorothy.Copy(); // Doll without accessories. Can't participate
            Doll cloneAnastasia = anastasia.Copy(); // Doll with a single dress. Can participate

            cloneAnastasia.Wear(blackOfficeSuit);

            Assert.AreEqual(cloneDorothy.CanParticipate, false);
            Assert.AreEqual(cloneAnastasia.CanParticipate, true);
        }

        [TestMethod()]
        public void StyleTest()
        {
            Doll cloneNataliya = nataliya.Copy(); // Doll without any accessories.
            Doll cloneBelle = belle.Copy(); // Doll with low-tier accessories, fully compatible.
            Doll cloneClaire = claire.Copy(); // Doll wilt mixed accessories, fully compatible
            Doll cloneAnastasia = anastasia.Copy(); // Doll with some uncompatible accessories.
            Doll cloneDorothy = dorothy.Copy(); // Doll with some excess bracelets

            // Total Style 9
            Dress belleSuit = cheapBlackOfficeSuit.Copy() as Dress;
            Purse bellePurse = cheapPurseA.Copy() as Purse;
            Bracelet belleBracelet = whiteGoldBracelet.Copy() as Bracelet;

            cloneBelle.Wear(belleSuit); // Style +3
            cloneBelle.Wear(bellePurse); // Style +2, doesn't add bonus because of black dress.
            cloneBelle.Wear(belleBracelet); // Style +4

            // Total Style = 15
            Dress claireDress = greenPartyDress.Copy() as Dress;
            Bracelet claireBraceletA = fantasyBraceletB.Copy() as Bracelet;
            Bracelet claireBraceletB = braidedBracelet.Copy() as Bracelet;
            Purse clairePurse = premiumPurse.Copy() as Purse;

            cloneClaire.Wear(claireDress); // Style +6
            cloneClaire.Wear(claireBraceletA); // Style +1
            cloneClaire.Wear(claireBraceletB); // Style +2
            cloneClaire.Wear(clairePurse); // Style +4, adds +2 bonus for being used along a non B/W dress

            // Total Style = 10
            Dress anastasiaDress = blackOfficeSuit.Copy() as Dress;
            Necklace anastasiaNecklace = diamondNecklace.Copy() as Necklace;
            Purse anastasiaPurse = midPurse.Copy() as Purse;
            Bracelet anastasiaBracelet = braidedBracelet.Copy() as Bracelet;

            cloneAnastasia.Wear(anastasiaDress); // Style +5
            cloneAnastasia.Wear(anastasiaNecklace); // Style +7, doesn't add to total because of suit dress
            cloneAnastasia.Wear(anastasiaPurse); // Style +3, doesn't add bonus because of black dress
            cloneAnastasia.Wear(anastasiaBracelet); // Style +2

            // Total Style = 19
            Dress dorothyDress = pinkPartyDress.Copy() as Dress;
            Purse dorothyPurse = premiumPurse.Copy() as Purse;
            Necklace dorothyNecklace = diamondNecklace.Copy() as Necklace;
            Bracelet dorothyBraceletA = braidedBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletB = diamondBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletC = fantasyBraceletA.Copy() as Bracelet;
            Bracelet dorothyBraceletD = fantasyBraceletB.Copy() as Bracelet;

            cloneDorothy.Wear(dorothyDress); // Style +4
            cloneDorothy.Wear(dorothyPurse); // Style +4, adds +2 bonus for being used along a non B/W dress
            cloneDorothy.Wear(dorothyNecklace); // Style +7, doesn't add to total because of non B/W/R dress
            cloneDorothy.Wear(dorothyBraceletA); // Style +2
            cloneDorothy.Wear(dorothyBraceletB); // Style +5
            cloneDorothy.Wear(dorothyBraceletC); // Style +2
            cloneDorothy.Wear(dorothyBraceletD); // Style +1, adds 0 because of penalty.

            Assert.AreEqual(cloneNataliya.Style, 0);
            Assert.AreEqual(cloneBelle.Style, 9);
            Assert.AreEqual(cloneClaire.Style, 15);
            Assert.AreEqual(cloneAnastasia.Style, 10);
            Assert.AreEqual(cloneDorothy.Style, 19);
        }

        [TestMethod()]
        public void WearTest()
        {
            // Restricted wears
            Doll cloneBelle = belle.Copy(); // Doll using a suit can't equip a necklace
            Doll cloneAnastasia = anastasia.Copy(); // Doll using a green dress can't equip a necklace
            Doll cloneDorothy = dorothy.Copy(); // Doll using a purse can't equip a new purse;
            Doll cloneNataliya = nataliya.Copy(); // Doll without a dress can't equip anything else

            Dress belleSuit = cheapBlackOfficeSuit.Copy() as Dress;
            Purse bellePurse = cheapPurseA.Copy() as Purse;
            Necklace belleNecklace = fantasyNecklaceA.Copy() as Necklace;

            cloneBelle.Wear(belleSuit);
            cloneBelle.Wear(bellePurse);
            cloneBelle.Wear(belleNecklace);

            Assert.AreEqual(cloneBelle.TotalAccessories, 2);

            Dress anastasiaDress = greenPartyDress.Copy() as Dress;
            Necklace anastasiaNecklace = diamondNecklace.Copy() as Necklace;

            cloneAnastasia.Wear(anastasiaDress);

            Assert.AreEqual(cloneAnastasia.Wear(anastasiaNecklace), false);

            Dress dorothyDress = blueCasualDress.Copy() as Dress;
            Purse dorothyPurse = midPurse.Copy() as Purse;
            Purse dorothyNewPurse = premiumPurse.Copy() as Purse;

            cloneDorothy.Wear(dorothyDress);
            cloneDorothy.Wear(dorothyPurse);

            Assert.AreEqual(dorothy.Wear(dorothyNewPurse), false);

            Assert.AreEqual(cloneNataliya.Wear(belleNecklace), false);
            Assert.AreEqual(cloneNataliya.TotalAccessories, 0);

            // CloneNataliya can equip only up to 5 bracelets
            cloneNataliya.Wear(belleSuit);

            for (int i = 0; i < 10; i++)
            {
                cloneNataliya.Wear(diamondBracelet.Copy());
            }

            Assert.AreEqual(cloneNataliya.BraceletCount, 5);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Doll cloneDorothy = dorothy.Copy(); // Doll with several accessories.

            Dress dorothyDress = pinkPartyDress.Copy() as Dress;
            Purse dorothyPurse = premiumPurse.Copy() as Purse;
            Necklace dorothyNecklace = diamondNecklace.Copy() as Necklace;
            Bracelet dorothyBraceletA = braidedBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletB = diamondBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletC = fantasyBraceletA.Copy() as Bracelet;
            Bracelet dorothyBraceletD = fantasyBraceletB.Copy() as Bracelet;

            cloneDorothy.Wear(dorothyDress);
            cloneDorothy.Wear(dorothyPurse);
            cloneDorothy.Wear(dorothyNecklace);
            cloneDorothy.Wear(dorothyBraceletA);
            cloneDorothy.Wear(dorothyBraceletB);
            cloneDorothy.Wear(dorothyBraceletC);
            cloneDorothy.Wear(dorothyBraceletD);

            // Removing a doll's dress will remove all accessories at once.
            cloneDorothy.Remove(dorothyDress);

            Assert.AreEqual(cloneDorothy.TotalAccessories, 0);
        }

        #endregion DOLL_METHODS

        #region JURY_METHODS

        [TestMethod()]
        public void AddContestantTest()
        {
            Doll cloneDorothy = dorothy.Copy();
            Doll cloneNataliya = nataliya.Copy();
            Doll cloneAnastasia = anastasia.Copy();
            Doll cloneBelle = belle.Copy();
            Doll cloneClaire = claire.Copy();
            Doll olga = new Doll("Olga");

            Assert.AreEqual(jury.TotalContestants, 0);

            cloneNataliya.Wear(whiteCasualDress.Copy());
            cloneAnastasia.Wear(blueCasualDress.Copy());
            cloneBelle.Wear(redOfficeSuit.Copy());
            cloneClaire.Wear(greenPartyDress.Copy());
            olga.Wear(yellowCasualDress.Copy());

            // Can only add dressed-up contestants.
            Assert.AreEqual(jury.AddContestant(cloneDorothy), false);
            Assert.AreEqual(jury.AddContestant(cloneNataliya), true);

            // Can only be up to 4 unique contestants.
            jury.AddContestant(cloneNataliya);
            jury.AddContestant(cloneNataliya);

            Assert.AreEqual(jury.TotalContestants, 1);

            // Remaining 3 contestants
            jury.AddContestant(cloneBelle);
            jury.AddContestant(cloneClaire);
            jury.AddContestant(cloneAnastasia);

            // Attempt to add a 5th contestant, fails
            Assert.AreEqual(jury.AddContestant(olga), false);
            Assert.AreEqual(jury.TotalContestants, 4);
        }

        [TestMethod()]
        public void GetWinnerTest()
        {
            jury.ClearContestants();
            
            Doll cloneBelle = belle.Copy(); // Doll with low-tier accessories, fully compatible.
            Doll cloneClaire = claire.Copy(); // Doll wilt mixed accessories, fully compatible
            Doll cloneAnastasia = anastasia.Copy(); // Doll with some uncompatible accessories.
            Doll cloneDorothy = dorothy.Copy(); // Doll with some excess bracelets

            // Total Style 9
            Dress belleSuit = cheapBlackOfficeSuit.Copy() as Dress;
            Purse bellePurse = cheapPurseA.Copy() as Purse;
            Bracelet belleBracelet = whiteGoldBracelet.Copy() as Bracelet;

            cloneBelle.Wear(belleSuit); // Style +3
            cloneBelle.Wear(bellePurse); // Style +2, doesn't add bonus because of black dress.
            cloneBelle.Wear(belleBracelet); // Style +4

            // Total Style = 15
            Dress claireDress = greenPartyDress.Copy() as Dress;
            Bracelet claireBraceletA = fantasyBraceletB.Copy() as Bracelet;
            Bracelet claireBraceletB = braidedBracelet.Copy() as Bracelet;
            Purse clairePurse = premiumPurse.Copy() as Purse;

            cloneClaire.Wear(claireDress); // Style +6
            cloneClaire.Wear(claireBraceletA); // Style +1
            cloneClaire.Wear(claireBraceletB); // Style +2
            cloneClaire.Wear(clairePurse); // Style +4, adds +2 bonus for being used along a non B/W dress

            // Total Style = 10
            Dress anastasiaDress = blackOfficeSuit.Copy() as Dress;
            Necklace anastasiaNecklace = diamondNecklace.Copy() as Necklace;
            Purse anastasiaPurse = midPurse.Copy() as Purse;
            Bracelet anastasiaBracelet = braidedBracelet.Copy() as Bracelet;

            cloneAnastasia.Wear(anastasiaDress); // Style +5
            cloneAnastasia.Wear(anastasiaNecklace); // Style +7, doesn't add to total because of suit dress
            cloneAnastasia.Wear(anastasiaPurse); // Style +3, doesn't add bonus because of black dress
            cloneAnastasia.Wear(anastasiaBracelet); // Style +2

            // Total Style = 19
            Dress dorothyDress = pinkPartyDress.Copy() as Dress;
            Purse dorothyPurse = premiumPurse.Copy() as Purse;
            Necklace dorothyNecklace = diamondNecklace.Copy() as Necklace;
            Bracelet dorothyBraceletA = braidedBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletB = diamondBracelet.Copy() as Bracelet;
            Bracelet dorothyBraceletC = fantasyBraceletA.Copy() as Bracelet;
            Bracelet dorothyBraceletD = fantasyBraceletB.Copy() as Bracelet;

            cloneDorothy.Wear(dorothyDress); // Style +4
            cloneDorothy.Wear(dorothyPurse); // Style +4, adds +2 bonus for being used along a non B/W dress
            cloneDorothy.Wear(dorothyNecklace); // Style +7, doesn't add to total because of non B/W/R dress
            cloneDorothy.Wear(dorothyBraceletA); // Style +2
            cloneDorothy.Wear(dorothyBraceletB); // Style +5
            cloneDorothy.Wear(dorothyBraceletC); // Style +2
            cloneDorothy.Wear(dorothyBraceletD); // Style +1, adds 0 because of penalty.            

            // Single contestant is deemed winner, no matter its score.
            jury.AddContestant(cloneBelle);
            Assert.AreEqual(jury.GetWinner().Name, cloneBelle.Name);

            // Three contestants, winner is the highest score.
            jury.AddContestant(cloneClaire);
            jury.AddContestant(cloneAnastasia);
            Assert.AreEqual(jury.GetWinner().Name, cloneClaire.Name);

            // Add a 4th contestant, changes result
            jury.AddContestant(cloneDorothy);
            Assert.AreEqual(jury.GetWinner().Name, cloneDorothy.Name);
        }

        #endregion JURY_METHODS
    }
}