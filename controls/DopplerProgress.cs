using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Reflection;

namespace Doppler.Controls
{
	/// <summary>
	/// Summary description for DopplerProgress.
	/// </summary>
	/// 
	public delegate void PositionChanged(int intValue);

	public class DopplerProgress : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Panel panelProgress;
		private System.Windows.Forms.Panel panelSlider;
		private int intMaximum;
		private int intMinimum;
		private int intValue;
		private Color colorFore;
		private Color colorBack;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event PositionChanged PositionChangedCallBack;	

		public DopplerProgress()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.panelSlider.Width = 0;
			// TODO: Add any initialization after the InitializeComponent call

		}
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelProgress = new System.Windows.Forms.Panel();
			this.panelSlider = new System.Windows.Forms.Panel();
			this.panelProgress.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelProgress
			// 
			this.panelProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelProgress.Controls.Add(this.panelSlider);
			this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelProgress.Location = new System.Drawing.Point(0, 0);
			this.panelProgress.Name = "panelProgress";
			this.panelProgress.Size = new System.Drawing.Size(360, 88);
			this.panelProgress.TabIndex = 20;
			this.panelProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelProgress_MouseDown);
			// 
			// panelSlider
			// 
			this.panelSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panelSlider.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(251)), ((System.Byte)(151)), ((System.Byte)(31)));
			this.panelSlider.Location = new System.Drawing.Point(0, 0);
			this.panelSlider.Name = "panelSlider";
			this.panelSlider.Size = new System.Drawing.Size(200, 86);
			this.panelSlider.TabIndex = 0;
			this.panelSlider.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSlider_MouseDown);
			// 
			// DopplerProgress
			// 
			this.Controls.Add(this.panelProgress);
			this.Name = "DopplerProgress";
			this.Size = new System.Drawing.Size(360, 88);
			this.panelProgress.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		delegate void SetValueDelegate(Object obj, Object val, Object[] index);

		public void SetControlProperty(Control ctrl, String propName, Object val)
		{
			PropertyInfo propInfo = ctrl.GetType().GetProperty(propName);
			Delegate dgtSetValue = new SetValueDelegate(propInfo.SetValue);
			ctrl.Invoke(dgtSetValue, new Object[3]{ ctrl, val, /*index*/null });
		}

		public int Value
		{
			
			get
			{
				return this.intValue;
			}
			set
			{
				if(value != 0)
				{
					
					this.intValue = value;
					double dblValue = GetStep() * value;
					//this.panelSlider.BackColor = this.colorFore;
					if(panelSlider.InvokeRequired)
					{
						SetControlProperty(this.panelSlider,"BackColor",this.colorFore);
						SetControlProperty(this.panelSlider,"Width",Convert.ToInt32(dblValue));
						//panelSlider.Invoke(new SetSliderWidth(panelSlider.Width),new object[] {intSetValue});
					} 
					else 
					{
						this.panelSlider.BackColor = this.colorFore;
						this.panelSlider.Width = Convert.ToInt32(dblValue);
					}
				} 
				else 
				{
					this.intValue = value;
				}
			}
		}

		private double GetStep()
		{
			double dblStep;
			if(this.intMaximum > 0)
			{
				dblStep = Convert.ToDouble(panelProgress.Width) / Convert.ToDouble(this.intMaximum);
			} 
			else 
			{
				dblStep = 1;
			}
			return dblStep;
		}

		private void panelSlider_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			double dblPosition = Convert.ToDouble(e.X) / GetStep();
			if(PositionChangedCallBack != null)
			{
				PositionChangedCallBack(Convert.ToInt32(dblPosition));
			}
		}

		private void panelProgress_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			double dblPosition = Convert.ToDouble(e.X) / GetStep();
			if(PositionChangedCallBack != null)
			{
				PositionChangedCallBack(Convert.ToInt32(dblPosition));
			}
		}

		public int Maximum
		{
			get
			{
				return this.intMaximum;
			}
			set
			{
				this.intMaximum = value;
			}
		}

		public int Minimum
		{
			get
			{
				return this.intMinimum;
			}
			set
			{
				this.intMinimum = value;
			}
		}

		public Color ProgressForeColor
		{
			get
			{
				return this.colorFore;
			}
			set
			{
				this.colorFore = value;
			}
		}

		public Color ProgressBackColor
		{
			get
			{
				return this.colorBack;
			}
			set
			{
				this.colorBack = value;
			}
		}
	}
}
