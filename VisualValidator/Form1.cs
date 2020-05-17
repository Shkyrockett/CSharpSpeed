using CSharpSpeed;
using InstrumentedLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace VisualValidator
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1
        : Form
    {
        /// <summary>
        /// The picture boxes
        /// </summary>
        private readonly List<PictureBox> pictureBoxes = new List<PictureBox>();

        /// <summary>
        /// The methods
        /// </summary>
        private List<MethodInfo> methods;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            pictureBoxes ??= new List<PictureBox>();

            comboBox1.DataSource = TestReflectionHelper.GetTypesWithHelpAttribute(typeof(VisualizerProviderAttribute)).ToList();
            comboBox1.ValueMember = "Name";
            comboBox1.SelectedItem = null;
        }

        /// <summary>
        /// The combo box1 selection change committed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flowLayoutPanel1.SuspendLayout();
            pictureBoxes?.RemoveAll(item => RemoveCanvas(flowLayoutPanel1, item));
            flowLayoutPanel1.ResumeLayout(true);

            methods = HelperExtensions.ListStaticMethodsWithAttribute((Type)((ComboBox)sender).SelectedItem, typeof(SourceCodeLocationProviderAttribute));
            flowLayoutPanel1.SuspendLayout();
            foreach (var method in methods)
            {
                AddCanvas(flowLayoutPanel1, pictureBoxes);
            }

            flowLayoutPanel1.ResumeLayout(true);

            comboBox2.DataSource = methods;
            comboBox2.ValueMember = "Name";
            comboBox2.SelectedItem = null;

            Invalidate(true);
        }

        /// <summary>
        /// The combo box2 selection change committed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ComboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        { }

        /// <summary>
        /// Removes the canvas.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="pictureBox">The picture box.</param>
        /// <returns></returns>
        private bool RemoveCanvas(FlowLayoutPanel parent, PictureBox pictureBox)
        {
            parent.Controls.Remove(pictureBox);
            pictureBox.Dispose();
            //pictureBox.Paint -= new PaintEventHandler(this.PictureBox1_Paint)
            return true;
        }

        /// <summary>
        /// Removes the canvas.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="pictureBoxes">The picture boxes.</param>
        /// <param name="pictureBox">The picture box.</param>
        internal static void RemoveCanvas(FlowLayoutPanel parent, List<PictureBox> pictureBoxes, PictureBox pictureBox)
        {
            parent.Controls.Remove(pictureBox);
            pictureBoxes.Remove(pictureBox);
            //pictureBox.Paint -= new PaintEventHandler(this.PictureBox1_Paint)
            pictureBox.Dispose();
        }

        /// <summary>
        /// Adds the canvas.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="pictureBoxes">The picture boxes.</param>
        private static void AddCanvas(FlowLayoutPanel parent, List<PictureBox> pictureBoxes)
        {
            var pictureBox = new PictureBox();
            ((ISupportInitialize)pictureBox).BeginInit();
            parent.Controls.Add(pictureBox);
            pictureBoxes.Add(pictureBox);
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Location = new Point(3, 3);
            pictureBox.Name = $"pictureBox{Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture)}";
            pictureBox.Size = new Size(143, 117);
            pictureBox.TabIndex = pictureBoxes.Count;
            pictureBox.TabStop = false;
            pictureBox.Image = pictureBox.ErrorImage;
            //pictureBox.Paint += new PaintEventHandler(this.PictureBox1_Paint)
            ((ISupportInitialize)pictureBox).EndInit();
        }
    }
}
