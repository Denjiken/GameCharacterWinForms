using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Linq;
using GameCharacterWinForms.Models;


namespace GameCharacterWinForms
{
        public partial class Form1 : Form
        {
        private List<GameCharacter> characterCollection = new List<GameCharacter>();
        private GameCharacter selectedCharacter;

        public Form1()
            {
                InitializeComponent();
            }

            private void btnAddCharacter_Click(object sender, EventArgs e)
            {
            // Create a new character based on user input
            string name = txtName.Text;
            int level;
            int health;
            if (!int.TryParse(txtLevel.Text, out level))
            {
            // Handle invalid input for level
            MessageBox.Show("Please enter a valid number for level.");
                return;
            }
            if (!int.TryParse(txtHealth.Text, out health))
            {
            // Handle invalid input for health
            MessageBox.Show("Please enter a valid number for health.");
                return;
            }
            GameCharacter newCharacter;
            if (cmbCharacterType.SelectedItem.ToString() == "Warrior")
            {
                int strength;
                if (!int.TryParse(txtStrength.Text, out strength))
                {
            // Handle invalid input for strength
            MessageBox.Show("Please enter a valid number for strength.");
                return;
                }
                newCharacter = new Warrior(name, level, health, strength);
            }
            else if (cmbCharacterType.SelectedItem.ToString() == "Mage")
            {
                int mana;
                int intelligence;
                if (!int.TryParse(txtMana.Text, out mana))
                {
            // Handle invalid input for mana
            MessageBox.Show("Please enter a valid number for mana.");
                return;
                }
                if (!int.TryParse(txtIntelligence.Text, out intelligence))
                {
            // Handle invalid input for intelligence
            MessageBox.Show("Please enter a valid number for intelligence.");
                return;
                }
                newCharacter = new Mage(name, level, health, mana, intelligence);
            }
            else
            {
                MessageBox.Show("Please select a valid character type.");
                return;
            }

            // Add the character to the collection and update the UI
            characterCollection.Add(newCharacter);
            listBoxCharacters.Items.Add(newCharacter.Name);
            MessageBox.Show($"{newCharacter.Name} added to your collection!");
        }

        private void btnSelectCharacter_Click(object sender, EventArgs e)
            {
            // Select a character from the collection
            if (listBoxCharacters.SelectedIndex >= 0)
            {
                selectedCharacter = characterCollection[listBoxCharacters.SelectedIndex];
                txtCharacterDetails.Text = selectedCharacter.ToString();
                MessageBox.Show($"{selectedCharacter.Name} selected!");
            }
            else
            {
                MessageBox.Show("Please select a character from the list.");
            }
        }

        private void btnAttack_Click(object sender, EventArgs e)
            {
            if (selectedCharacter == null)
            {
                MessageBox.Show("No character selected!");
                return;
            }
            selectedCharacter.Attack();
            battleLog.Items.Add($"{selectedCharacter.Name} performed an attack.");
            txtCharacterDetails.Text = selectedCharacter.ToString();
        }

        private void btnDefend_Click(object sender, EventArgs e)
            {
            if (selectedCharacter == null)
            {
                MessageBox.Show("No character selected!");
                return;
            }
            selectedCharacter.Defend();
            battleLog.Items.Add($"{selectedCharacter.Name} defended.");
            txtCharacterDetails.Text = selectedCharacter.ToString();
        }

        private void btnLevelUp_Click(object sender, EventArgs e)
            {
            if (selectedCharacter == null)
            {
                MessageBox.Show("No character selected!");
                return;
            }
            selectedCharacter.LevelUp();
            battleLog.Items.Add($"{selectedCharacter.Name} leveled up.");
            txtCharacterDetails.Text = selectedCharacter.ToString();
        }

        private void cmbCharacterType_SelectedIndexChanged(object sender, EventArgs e)
            {
            if (cmbCharacterType.SelectedItem.ToString() == "Warrior")
            {
                txtStrength.Enabled = true;
                txtMana.Enabled = false;
                txtIntelligence.Enabled = false;

            }
            else if (cmbCharacterType.SelectedItem.ToString() == "Mage")
            {
                txtMana.Enabled = true;
                txtIntelligence.Enabled = true;
                txtStrength.Enabled = false;

            }
            else
            {
                MessageBox.Show("Please select a valid character type.");
                return;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BgImage_Click(object sender, EventArgs e)
        {

        }

        private void cmbCharacterType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
