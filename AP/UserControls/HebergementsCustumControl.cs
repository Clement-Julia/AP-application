﻿using AP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP.Forms
{
    public partial class HebergementsCustumControl : UserControl
    {
        private Hebergement _hebergement { get; set; }
        private Utilisateur _utilisateur { get; set; }
        private FormHebergements _formHebergement { get; set; }
        public HebergementsCustumControl(Hebergement hebergement, Utilisateur utilisateur, FormHebergements formHebergements)
        {
            InitializeComponent();
            this._hebergement = hebergement;
            this._utilisateur = utilisateur;
            this._formHebergement = formHebergements;
            LabelNomHebergement.Text = _hebergement.Libelle;
            LabelNbReservationEnCours.Text = _hebergement.GetNombreReservationEnCours();
            LabelNbReservationAVenir.Text = _hebergement.GetNombreReservationAVenir();
        }

        public HebergementsCustumControl()
        {
            InitializeComponent();
        }

        private void BtnInfos_Click(object sender, EventArgs e)
        {
            HebergementInfos form = new HebergementInfos(_hebergement);
            ShowInParent(form);
        }

        private void BtnModification_Click(object sender, EventArgs e)
        {
            modifHebergement form = new modifHebergement(_hebergement, _utilisateur, _formHebergement);
            ShowInParent(form);
        }

        private void ShowInParent(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoScroll = true;
            _formHebergement.Controls.Add(form);
            _formHebergement.Tag = form;
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
    }
}
