namespace WindowsFormsApp2.Ejercicios.Area.Vistas
{
    partial class FrmArea
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlDibujo = new WindowsFormsApp2.Comun.clsPanelDoble();
            this.lblX = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lbxVertices = new System.Windows.Forms.ListBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPasoAPaso = new System.Windows.Forms.Button();
            this.btnProbarMil = new System.Windows.Forms.Button();
            this.chkMostrarPuntos = new System.Windows.Forms.CheckBox();
            this.chkMostrarCuadricula = new System.Windows.Forms.CheckBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblSentido = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.txtPasos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlDibujo
            // 
            this.pnlDibujo.BackColor = System.Drawing.Color.White;
            this.pnlDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDibujo.Location = new System.Drawing.Point(10, 10);
            this.pnlDibujo.Name = "pnlDibujo";
            this.pnlDibujo.Size = new System.Drawing.Size(700, 680);
            this.pnlDibujo.TabIndex = 0;
            this.pnlDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDibujo_Paint);
            this.pnlDibujo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlDibujo_MouseClick);
            this.pnlDibujo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlDibujo_MouseMove);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(725, 14);
            this.lblX.Name = "lblX";
            this.lblX.Text = "X:";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(750, 10);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(60, 20);
            this.txtX.TabIndex = 1;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(820, 14);
            this.lblY.Name = "lblY";
            this.lblY.Text = "Y:";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(845, 10);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(60, 20);
            this.txtY.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(920, 8);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 28);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lbxVertices
            // 
            this.lbxVertices.Location = new System.Drawing.Point(725, 45);
            this.lbxVertices.Name = "lbxVertices";
            this.lbxVertices.Size = new System.Drawing.Size(190, 180);
            this.lbxVertices.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(925, 45);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(180, 28);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar poligono";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(925, 80);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(180, 28);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular area";
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(925, 115);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(180, 28);
            this.btnDeshacer.TabIndex = 7;
            this.btnDeshacer.Text = "Deshacer ultimo vertice";
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(925, 150);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 28);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPasoAPaso
            // 
            this.btnPasoAPaso.Location = new System.Drawing.Point(925, 185);
            this.btnPasoAPaso.Name = "btnPasoAPaso";
            this.btnPasoAPaso.Size = new System.Drawing.Size(180, 28);
            this.btnPasoAPaso.TabIndex = 9;
            this.btnPasoAPaso.Text = "Ver paso a paso";
            this.btnPasoAPaso.Click += new System.EventHandler(this.btnPasoAPaso_Click);
            // 
            // btnProbarMil
            // 
            this.btnProbarMil.Location = new System.Drawing.Point(725, 235);
            this.btnProbarMil.Name = "btnProbarMil";
            this.btnProbarMil.Size = new System.Drawing.Size(380, 28);
            this.btnProbarMil.TabIndex = 10;
            this.btnProbarMil.Text = "Probar con 1.000 vertices";
            this.btnProbarMil.Click += new System.EventHandler(this.btnProbarMil_Click);
            // 
            // chkMostrarPuntos
            // 
            this.chkMostrarPuntos.AutoSize = true;
            this.chkMostrarPuntos.Checked = true;
            this.chkMostrarPuntos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMostrarPuntos.Location = new System.Drawing.Point(725, 272);
            this.chkMostrarPuntos.Name = "chkMostrarPuntos";
            this.chkMostrarPuntos.TabIndex = 11;
            this.chkMostrarPuntos.Text = "Mostrar puntos";
            this.chkMostrarPuntos.CheckedChanged += new System.EventHandler(this.chkOpcion_CheckedChanged);
            // 
            // chkMostrarCuadricula
            // 
            this.chkMostrarCuadricula.AutoSize = true;
            this.chkMostrarCuadricula.Checked = true;
            this.chkMostrarCuadricula.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMostrarCuadricula.Location = new System.Drawing.Point(865, 272);
            this.chkMostrarCuadricula.Name = "chkMostrarCuadricula";
            this.chkMostrarCuadricula.TabIndex = 12;
            this.chkMostrarCuadricula.Text = "Mostrar cuadricula";
            this.chkMostrarCuadricula.CheckedChanged += new System.EventHandler(this.chkOpcion_CheckedChanged);
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblArea.Location = new System.Drawing.Point(725, 305);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(390, 50);
            this.lblArea.Text = "Area = ? unidades cuadradas";
            // 
            // lblSentido
            // 
            this.lblSentido.Location = new System.Drawing.Point(725, 358);
            this.lblSentido.Name = "lblSentido";
            this.lblSentido.Size = new System.Drawing.Size(390, 22);
            this.lblSentido.Text = "Sentido: ?";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Location = new System.Drawing.Point(725, 382);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(390, 50);
            this.lblMensaje.Text = "";
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Location = new System.Drawing.Point(725, 435);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Text = "Mouse: (-, -)";
            // 
            // txtPasos
            // 
            this.txtPasos.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtPasos.Location = new System.Drawing.Point(725, 460);
            this.txtPasos.Multiline = true;
            this.txtPasos.Name = "txtPasos";
            this.txtPasos.ReadOnly = true;
            this.txtPasos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPasos.Size = new System.Drawing.Size(390, 230);
            this.txtPasos.TabIndex = 13;
            this.txtPasos.WordWrap = false;
            // 
            // FrmArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1130, 700);
            this.Controls.Add(this.pnlDibujo);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lbxVertices);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnPasoAPaso);
            this.Controls.Add(this.btnProbarMil);
            this.Controls.Add(this.chkMostrarPuntos);
            this.Controls.Add(this.chkMostrarCuadricula);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.lblSentido);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblCoordenadas);
            this.Controls.Add(this.txtPasos);
            this.Name = "FrmArea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora grafica de area de poligonos (formula de Gauss)";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private WindowsFormsApp2.Comun.clsPanelDoble pnlDibujo;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblSentido;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label lblCoordenadas;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtPasos;
        private System.Windows.Forms.ListBox lbxVertices;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnPasoAPaso;
        private System.Windows.Forms.Button btnProbarMil;
        private System.Windows.Forms.CheckBox chkMostrarPuntos;
        private System.Windows.Forms.CheckBox chkMostrarCuadricula;
    }
}


