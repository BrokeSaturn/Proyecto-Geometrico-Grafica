namespace WindowsFormsApp2.Distancia
{
    partial class FrmDistanciaMinima
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
            this.tlpContenedorPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpPanelIzquierdo = new System.Windows.Forms.TableLayoutPanel();
            this.grpDatosEntrada = new System.Windows.Forms.GroupBox();
            this.tlpCoordenadas = new System.Windows.Forms.TableLayoutPanel();
            this.lblEncabezadoPunto = new System.Windows.Forms.Label();
            this.lblEncabezadoX = new System.Windows.Forms.Label();
            this.lblEncabezadoY = new System.Windows.Forms.Label();
            this.lblPuntoA = new System.Windows.Forms.Label();
            this.txtCoordenadaAx = new System.Windows.Forms.TextBox();
            this.txtCoordenadaAy = new System.Windows.Forms.TextBox();
            this.lblPuntoB = new System.Windows.Forms.Label();
            this.txtCoordenadaBx = new System.Windows.Forms.TextBox();
            this.txtCoordenadaBy = new System.Windows.Forms.TextBox();
            this.lblPuntoP = new System.Windows.Forms.Label();
            this.txtCoordenadaPx = new System.Windows.Forms.TextBox();
            this.txtCoordenadaPy = new System.Windows.Forms.TextBox();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCalcularDistancia = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRestablecerEjemplo = new System.Windows.Forms.Button();
            this.lblMensajeValidacion = new System.Windows.Forms.Label();
            this.grpResultados = new System.Windows.Forms.GroupBox();
            this.tlpResultados = new System.Windows.Forms.TableLayoutPanel();
            this.lblEtiquetaVectorAB = new System.Windows.Forms.Label();
            this.lblVectorAB = new System.Windows.Forms.Label();
            this.lblEtiquetaVectorAP = new System.Windows.Forms.Label();
            this.lblVectorAP = new System.Windows.Forms.Label();
            this.lblEtiquetaParametroOriginal = new System.Windows.Forms.Label();
            this.lblParametroOriginal = new System.Windows.Forms.Label();
            this.lblEtiquetaParametroRestringido = new System.Windows.Forms.Label();
            this.lblParametroRestringido = new System.Windows.Forms.Label();
            this.lblEtiquetaPuntoQ = new System.Windows.Forms.Label();
            this.lblPuntoQ = new System.Windows.Forms.Label();
            this.lblEtiquetaDistanciaMinima = new System.Windows.Forms.Label();
            this.lblDistanciaMinima = new System.Windows.Forms.Label();
            this.lblEtiquetaClasificacion = new System.Windows.Forms.Label();
            this.lblClasificacion = new System.Windows.Forms.Label();
            this.lblEtiquetaPertenencia = new System.Windows.Forms.Label();
            this.lblPertenencia = new System.Windows.Forms.Label();
            this.grpGraficoTrayectoria = new System.Windows.Forms.GroupBox();
            this.pnlGraficoTrayectoria = new WindowsFormsApp2.Distancia.clsPanelGrafico();
            this.tlpContenedorPrincipal.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.tlpPanelIzquierdo.SuspendLayout();
            this.grpDatosEntrada.SuspendLayout();
            this.tlpCoordenadas.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            this.grpResultados.SuspendLayout();
            this.tlpResultados.SuspendLayout();
            this.grpGraficoTrayectoria.SuspendLayout();
            this.SuspendLayout();

            this.tlpContenedorPrincipal.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.tlpContenedorPrincipal.ColumnCount = 2;
            this.tlpContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenedorPrincipal.Controls.Add(this.pnlEncabezado, 0, 0);
            this.tlpContenedorPrincipal.Controls.Add(this.tlpPanelIzquierdo, 0, 1);
            this.tlpContenedorPrincipal.Controls.Add(this.grpGraficoTrayectoria, 1, 1);
            this.tlpContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContenedorPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpContenedorPrincipal.Name = "tlpContenedorPrincipal";
            this.tlpContenedorPrincipal.Padding = new System.Windows.Forms.Padding(12);
            this.tlpContenedorPrincipal.RowCount = 2;
            this.tlpContenedorPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpContenedorPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenedorPrincipal.Size = new System.Drawing.Size(1200, 760);
            this.tlpContenedorPrincipal.TabIndex = 0;

            this.pnlEncabezado.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.tlpContenedorPrincipal.SetColumnSpan(this.pnlEncabezado, 2);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEncabezado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.TabIndex = 2;

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Distancia minima a un obstaculo";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblSubtitulo.Location = new System.Drawing.Point(19, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Proyeccion ortogonal del obstaculo P sobre el segmento AB recorrido por el vehiculo";

            this.tlpPanelIzquierdo.ColumnCount = 1;
            this.tlpPanelIzquierdo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelIzquierdo.Controls.Add(this.grpDatosEntrada, 0, 0);
            this.tlpPanelIzquierdo.Controls.Add(this.flpAcciones, 0, 1);
            this.tlpPanelIzquierdo.Controls.Add(this.lblMensajeValidacion, 0, 2);
            this.tlpPanelIzquierdo.Controls.Add(this.grpResultados, 0, 3);
            this.tlpPanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelIzquierdo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPanelIzquierdo.Name = "tlpPanelIzquierdo";
            this.tlpPanelIzquierdo.RowCount = 4;
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelIzquierdo.TabIndex = 0;

            this.grpDatosEntrada.BackColor = System.Drawing.Color.White;
            this.grpDatosEntrada.Controls.Add(this.tlpCoordenadas);
            this.grpDatosEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatosEntrada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDatosEntrada.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpDatosEntrada.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.grpDatosEntrada.Name = "grpDatosEntrada";
            this.grpDatosEntrada.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpDatosEntrada.TabIndex = 0;
            this.grpDatosEntrada.TabStop = false;
            this.grpDatosEntrada.Text = "Datos de entrada";

            this.tlpCoordenadas.ColumnCount = 3;
            this.tlpCoordenadas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tlpCoordenadas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpCoordenadas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tlpCoordenadas.Controls.Add(this.lblEncabezadoPunto, 0, 0);
            this.tlpCoordenadas.Controls.Add(this.lblEncabezadoX, 1, 0);
            this.tlpCoordenadas.Controls.Add(this.lblEncabezadoY, 2, 0);
            this.tlpCoordenadas.Controls.Add(this.lblPuntoA, 0, 1);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaAx, 1, 1);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaAy, 2, 1);
            this.tlpCoordenadas.Controls.Add(this.lblPuntoB, 0, 2);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaBx, 1, 2);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaBy, 2, 2);
            this.tlpCoordenadas.Controls.Add(this.lblPuntoP, 0, 3);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaPx, 1, 3);
            this.tlpCoordenadas.Controls.Add(this.txtCoordenadaPy, 2, 3);
            this.tlpCoordenadas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCoordenadas.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tlpCoordenadas.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.tlpCoordenadas.Name = "tlpCoordenadas";
            this.tlpCoordenadas.RowCount = 4;
            this.tlpCoordenadas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpCoordenadas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCoordenadas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCoordenadas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tlpCoordenadas.TabIndex = 0;

            this.lblEncabezadoPunto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEncabezadoPunto.AutoSize = true;
            this.lblEncabezadoPunto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEncabezadoPunto.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEncabezadoPunto.Name = "lblEncabezadoPunto";
            this.lblEncabezadoPunto.TabIndex = 10;
            this.lblEncabezadoPunto.Text = "Punto";

            this.lblEncabezadoX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEncabezadoX.AutoSize = true;
            this.lblEncabezadoX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEncabezadoX.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEncabezadoX.Name = "lblEncabezadoX";
            this.lblEncabezadoX.TabIndex = 11;
            this.lblEncabezadoX.Text = "Coordenada X";

            this.lblEncabezadoY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEncabezadoY.AutoSize = true;
            this.lblEncabezadoY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEncabezadoY.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEncabezadoY.Name = "lblEncabezadoY";
            this.lblEncabezadoY.TabIndex = 12;
            this.lblEncabezadoY.Text = "Coordenada Y";

            this.lblPuntoA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPuntoA.AutoSize = true;
            this.lblPuntoA.Name = "lblPuntoA";
            this.lblPuntoA.TabIndex = 13;
            this.lblPuntoA.Text = "A - Punto inicial";

            this.txtCoordenadaAx.AccessibleName = "Coordenada Ax";
            this.txtCoordenadaAx.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaAx.Name = "txtCoordenadaAx";
            this.txtCoordenadaAx.TabIndex = 0;
            this.txtCoordenadaAx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaAx.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaAx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.txtCoordenadaAy.AccessibleName = "Coordenada Ay";
            this.txtCoordenadaAy.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaAy.Name = "txtCoordenadaAy";
            this.txtCoordenadaAy.TabIndex = 1;
            this.txtCoordenadaAy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaAy.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaAy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.lblPuntoB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPuntoB.AutoSize = true;
            this.lblPuntoB.Name = "lblPuntoB";
            this.lblPuntoB.TabIndex = 14;
            this.lblPuntoB.Text = "B - Punto final";

            this.txtCoordenadaBx.AccessibleName = "Coordenada Bx";
            this.txtCoordenadaBx.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaBx.Name = "txtCoordenadaBx";
            this.txtCoordenadaBx.TabIndex = 2;
            this.txtCoordenadaBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaBx.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.txtCoordenadaBy.AccessibleName = "Coordenada By";
            this.txtCoordenadaBy.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaBy.Name = "txtCoordenadaBy";
            this.txtCoordenadaBy.TabIndex = 3;
            this.txtCoordenadaBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaBy.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.lblPuntoP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPuntoP.AutoSize = true;
            this.lblPuntoP.Name = "lblPuntoP";
            this.lblPuntoP.TabIndex = 15;
            this.lblPuntoP.Text = "P - Obstaculo";

            this.txtCoordenadaPx.AccessibleName = "Coordenada Px";
            this.txtCoordenadaPx.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaPx.Name = "txtCoordenadaPx";
            this.txtCoordenadaPx.TabIndex = 4;
            this.txtCoordenadaPx.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaPx.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaPx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.txtCoordenadaPy.AccessibleName = "Coordenada Py";
            this.txtCoordenadaPy.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtCoordenadaPy.Name = "txtCoordenadaPy";
            this.txtCoordenadaPy.TabIndex = 5;
            this.txtCoordenadaPy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCoordenadaPy.TextChanged += new System.EventHandler(this.txtCoordenada_TextChanged);
            this.txtCoordenadaPy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCoordenada_KeyPress);

            this.flpAcciones.Controls.Add(this.btnCalcularDistancia);
            this.flpAcciones.Controls.Add(this.btnLimpiar);
            this.flpAcciones.Controls.Add(this.btnRestablecerEjemplo);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpAcciones.Margin = new System.Windows.Forms.Padding(0);
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.TabIndex = 1;

            this.btnCalcularDistancia.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCalcularDistancia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularDistancia.FlatAppearance.BorderSize = 0;
            this.btnCalcularDistancia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularDistancia.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCalcularDistancia.ForeColor = System.Drawing.Color.White;
            this.btnCalcularDistancia.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.btnCalcularDistancia.Name = "btnCalcularDistancia";
            this.btnCalcularDistancia.Size = new System.Drawing.Size(392, 42);
            this.btnCalcularDistancia.TabIndex = 0;
            this.btnCalcularDistancia.Text = "&Calcular distancia  (Enter)";
            this.btnCalcularDistancia.UseVisualStyleBackColor = false;
            this.btnCalcularDistancia.Click += new System.EventHandler(this.btnCalcularDistancia_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(193, 36);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnRestablecerEjemplo.BackColor = System.Drawing.Color.White;
            this.btnRestablecerEjemplo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestablecerEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnRestablecerEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestablecerEjemplo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnRestablecerEjemplo.Name = "btnRestablecerEjemplo";
            this.btnRestablecerEjemplo.Size = new System.Drawing.Size(193, 36);
            this.btnRestablecerEjemplo.TabIndex = 2;
            this.btnRestablecerEjemplo.Text = "&Restablecer ejemplo";
            this.btnRestablecerEjemplo.UseVisualStyleBackColor = false;
            this.btnRestablecerEjemplo.Click += new System.EventHandler(this.btnRestablecerEjemplo_Click);

            this.lblMensajeValidacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensajeValidacion.Margin = new System.Windows.Forms.Padding(0, 4, 0, 6);
            this.lblMensajeValidacion.Name = "lblMensajeValidacion";
            this.lblMensajeValidacion.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblMensajeValidacion.TabIndex = 2;
            this.lblMensajeValidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.grpResultados.BackColor = System.Drawing.Color.White;
            this.grpResultados.Controls.Add(this.tlpResultados);
            this.grpResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResultados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpResultados.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpResultados.Margin = new System.Windows.Forms.Padding(0);
            this.grpResultados.Name = "grpResultados";
            this.grpResultados.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.grpResultados.TabIndex = 3;
            this.grpResultados.TabStop = false;
            this.grpResultados.Text = "Resultados";

            this.tlpResultados.AutoScroll = true;
            this.tlpResultados.ColumnCount = 2;
            this.tlpResultados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpResultados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResultados.Controls.Add(this.lblEtiquetaVectorAB, 0, 0);
            this.tlpResultados.Controls.Add(this.lblVectorAB, 1, 0);
            this.tlpResultados.Controls.Add(this.lblEtiquetaVectorAP, 0, 1);
            this.tlpResultados.Controls.Add(this.lblVectorAP, 1, 1);
            this.tlpResultados.Controls.Add(this.lblEtiquetaParametroOriginal, 0, 2);
            this.tlpResultados.Controls.Add(this.lblParametroOriginal, 1, 2);
            this.tlpResultados.Controls.Add(this.lblEtiquetaParametroRestringido, 0, 3);
            this.tlpResultados.Controls.Add(this.lblParametroRestringido, 1, 3);
            this.tlpResultados.Controls.Add(this.lblEtiquetaPuntoQ, 0, 4);
            this.tlpResultados.Controls.Add(this.lblPuntoQ, 1, 4);
            this.tlpResultados.Controls.Add(this.lblEtiquetaDistanciaMinima, 0, 5);
            this.tlpResultados.Controls.Add(this.lblDistanciaMinima, 1, 5);
            this.tlpResultados.Controls.Add(this.lblEtiquetaClasificacion, 0, 6);
            this.tlpResultados.Controls.Add(this.lblClasificacion, 1, 6);
            this.tlpResultados.Controls.Add(this.lblEtiquetaPertenencia, 0, 7);
            this.tlpResultados.Controls.Add(this.lblPertenencia, 1, 7);
            this.tlpResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResultados.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tlpResultados.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.tlpResultados.Name = "tlpResultados";
            this.tlpResultados.RowCount = 9;
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResultados.TabIndex = 0;

            this.lblEtiquetaVectorAB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVectorAB.AutoSize = true;
            this.lblEtiquetaVectorAB.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaVectorAB.Name = "lblEtiquetaVectorAB";
            this.lblEtiquetaVectorAB.Text = "Vector AB = B - A";

            this.lblVectorAB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVectorAB.AutoSize = true;
            this.lblVectorAB.Name = "lblVectorAB";
            this.lblVectorAB.Text = "-";

            this.lblEtiquetaVectorAP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVectorAP.AutoSize = true;
            this.lblEtiquetaVectorAP.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaVectorAP.Name = "lblEtiquetaVectorAP";
            this.lblEtiquetaVectorAP.Text = "Vector AP = P - A";

            this.lblVectorAP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVectorAP.AutoSize = true;
            this.lblVectorAP.Name = "lblVectorAP";
            this.lblVectorAP.Text = "-";

            this.lblEtiquetaParametroOriginal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaParametroOriginal.AutoSize = true;
            this.lblEtiquetaParametroOriginal.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaParametroOriginal.Name = "lblEtiquetaParametroOriginal";
            this.lblEtiquetaParametroOriginal.Text = "Parametro t*";

            this.lblParametroOriginal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblParametroOriginal.AutoSize = true;
            this.lblParametroOriginal.Name = "lblParametroOriginal";
            this.lblParametroOriginal.Text = "-";

            this.lblEtiquetaParametroRestringido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaParametroRestringido.AutoSize = true;
            this.lblEtiquetaParametroRestringido.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaParametroRestringido.Name = "lblEtiquetaParametroRestringido";
            this.lblEtiquetaParametroRestringido.Text = "Parametro t";

            this.lblParametroRestringido.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblParametroRestringido.AutoSize = true;
            this.lblParametroRestringido.Name = "lblParametroRestringido";
            this.lblParametroRestringido.Text = "-";

            this.lblEtiquetaPuntoQ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaPuntoQ.AutoSize = true;
            this.lblEtiquetaPuntoQ.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaPuntoQ.Name = "lblEtiquetaPuntoQ";
            this.lblEtiquetaPuntoQ.Text = "Punto Q";

            this.lblPuntoQ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPuntoQ.AutoSize = true;
            this.lblPuntoQ.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblPuntoQ.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblPuntoQ.Name = "lblPuntoQ";
            this.lblPuntoQ.Text = "-";

            this.lblEtiquetaDistanciaMinima.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaDistanciaMinima.AutoSize = true;
            this.lblEtiquetaDistanciaMinima.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaDistanciaMinima.Name = "lblEtiquetaDistanciaMinima";
            this.lblEtiquetaDistanciaMinima.Text = "Distancia minima";

            this.lblDistanciaMinima.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistanciaMinima.AutoSize = true;
            this.lblDistanciaMinima.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDistanciaMinima.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblDistanciaMinima.Name = "lblDistanciaMinima";
            this.lblDistanciaMinima.Text = "-";

            this.lblEtiquetaClasificacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaClasificacion.AutoSize = true;
            this.lblEtiquetaClasificacion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaClasificacion.Name = "lblEtiquetaClasificacion";
            this.lblEtiquetaClasificacion.Text = "Clasificacion";

            this.lblClasificacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblClasificacion.AutoSize = true;
            this.lblClasificacion.Name = "lblClasificacion";
            this.lblClasificacion.Text = "-";

            this.lblEtiquetaPertenencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaPertenencia.AutoSize = true;
            this.lblEtiquetaPertenencia.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaPertenencia.Name = "lblEtiquetaPertenencia";
            this.lblEtiquetaPertenencia.Text = "Q pertenece a AB";

            this.lblPertenencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPertenencia.AutoSize = true;
            this.lblPertenencia.Name = "lblPertenencia";
            this.lblPertenencia.Text = "-";

            this.grpGraficoTrayectoria.BackColor = System.Drawing.Color.White;
            this.grpGraficoTrayectoria.Controls.Add(this.pnlGraficoTrayectoria);
            this.grpGraficoTrayectoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGraficoTrayectoria.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpGraficoTrayectoria.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpGraficoTrayectoria.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.grpGraficoTrayectoria.Name = "grpGraficoTrayectoria";
            this.grpGraficoTrayectoria.Padding = new System.Windows.Forms.Padding(8);
            this.grpGraficoTrayectoria.TabIndex = 1;
            this.grpGraficoTrayectoria.TabStop = false;
            this.grpGraficoTrayectoria.Text = "Representacion grafica de la trayectoria";

            this.pnlGraficoTrayectoria.BackColor = System.Drawing.Color.White;
            this.pnlGraficoTrayectoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGraficoTrayectoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlGraficoTrayectoria.Name = "pnlGraficoTrayectoria";
            this.pnlGraficoTrayectoria.TabIndex = 0;
            this.pnlGraficoTrayectoria.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGraficoTrayectoria_Paint);

            this.AcceptButton = this.btnCalcularDistancia;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.tlpContenedorPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(980, 740);
            this.Name = "FrmDistanciaMinima";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Distancia minima entre un obstaculo y una trayectoria";
            this.Load += new System.EventHandler(this.FrmDistanciaMinima_Load);
            this.tlpContenedorPrincipal.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.tlpPanelIzquierdo.ResumeLayout(false);
            this.grpDatosEntrada.ResumeLayout(false);
            this.tlpCoordenadas.ResumeLayout(false);
            this.tlpCoordenadas.PerformLayout();
            this.flpAcciones.ResumeLayout(false);
            this.grpResultados.ResumeLayout(false);
            this.tlpResultados.ResumeLayout(false);
            this.tlpResultados.PerformLayout();
            this.grpGraficoTrayectoria.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContenedorPrincipal;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TableLayoutPanel tlpPanelIzquierdo;
        private System.Windows.Forms.GroupBox grpDatosEntrada;
        private System.Windows.Forms.TableLayoutPanel tlpCoordenadas;
        private System.Windows.Forms.Label lblEncabezadoPunto;
        private System.Windows.Forms.Label lblEncabezadoX;
        private System.Windows.Forms.Label lblEncabezadoY;
        private System.Windows.Forms.Label lblPuntoA;
        private System.Windows.Forms.TextBox txtCoordenadaAx;
        private System.Windows.Forms.TextBox txtCoordenadaAy;
        private System.Windows.Forms.Label lblPuntoB;
        private System.Windows.Forms.TextBox txtCoordenadaBx;
        private System.Windows.Forms.TextBox txtCoordenadaBy;
        private System.Windows.Forms.Label lblPuntoP;
        private System.Windows.Forms.TextBox txtCoordenadaPx;
        private System.Windows.Forms.TextBox txtCoordenadaPy;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private System.Windows.Forms.Button btnCalcularDistancia;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRestablecerEjemplo;
        private System.Windows.Forms.Label lblMensajeValidacion;
        private System.Windows.Forms.GroupBox grpResultados;
        private System.Windows.Forms.TableLayoutPanel tlpResultados;
        private System.Windows.Forms.Label lblEtiquetaVectorAB;
        private System.Windows.Forms.Label lblVectorAB;
        private System.Windows.Forms.Label lblEtiquetaVectorAP;
        private System.Windows.Forms.Label lblVectorAP;
        private System.Windows.Forms.Label lblEtiquetaParametroOriginal;
        private System.Windows.Forms.Label lblParametroOriginal;
        private System.Windows.Forms.Label lblEtiquetaParametroRestringido;
        private System.Windows.Forms.Label lblParametroRestringido;
        private System.Windows.Forms.Label lblEtiquetaPuntoQ;
        private System.Windows.Forms.Label lblPuntoQ;
        private System.Windows.Forms.Label lblEtiquetaDistanciaMinima;
        private System.Windows.Forms.Label lblDistanciaMinima;
        private System.Windows.Forms.Label lblEtiquetaClasificacion;
        private System.Windows.Forms.Label lblClasificacion;
        private System.Windows.Forms.Label lblEtiquetaPertenencia;
        private System.Windows.Forms.Label lblPertenencia;
        private System.Windows.Forms.GroupBox grpGraficoTrayectoria;
        private WindowsFormsApp2.Distancia.clsPanelGrafico pnlGraficoTrayectoria;
    }
}
