namespace WindowsFormsApp2.Ejercicios.Triangulacion.Vistas
{
    partial class FrmTriangulacion
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
            this.components = new System.ComponentModel.Container();
            this.tlpContenedorPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpPanelIzquierdo = new System.Windows.Forms.TableLayoutPanel();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.tlpAcciones = new System.Windows.Forms.TableLayoutPanel();
            this.btnTriangular = new System.Windows.Forms.Button();
            this.btnCerrarPoligono = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCargarEjemplo = new System.Windows.Forms.Button();
            this.chkPasoAPaso = new System.Windows.Forms.CheckBox();
            this.chkAjustarCuadricula = new System.Windows.Forms.CheckBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpResultados = new System.Windows.Forms.GroupBox();
            this.tlpResultados = new System.Windows.Forms.TableLayoutPanel();
            this.lblEtiquetaVertices = new System.Windows.Forms.Label();
            this.lblValorVertices = new System.Windows.Forms.Label();
            this.lblEtiquetaTriangulos = new System.Windows.Forms.Label();
            this.lblValorTriangulos = new System.Windows.Forms.Label();
            this.lblEtiquetaEsperados = new System.Windows.Forms.Label();
            this.lblValorEsperados = new System.Windows.Forms.Label();
            this.lblEtiquetaAreaPoligono = new System.Windows.Forms.Label();
            this.lblValorAreaPoligono = new System.Windows.Forms.Label();
            this.lblEtiquetaSumaAreas = new System.Windows.Forms.Label();
            this.lblValorSumaAreas = new System.Windows.Forms.Label();
            this.lblEtiquetaDiferencia = new System.Windows.Forms.Label();
            this.lblValorDiferencia = new System.Windows.Forms.Label();
            this.lblEtiquetaVerificacion = new System.Windows.Forms.Label();
            this.lblValorVerificacion = new System.Windows.Forms.Label();
            this.lblEtiquetaTipo = new System.Windows.Forms.Label();
            this.lblValorTipo = new System.Windows.Forms.Label();
            this.lblEtiquetaOrientacion = new System.Windows.Forms.Label();
            this.lblValorOrientacion = new System.Windows.Forms.Label();
            this.grpDetalle = new System.Windows.Forms.GroupBox();
            this.txtResultados = new System.Windows.Forms.TextBox();
            this.grpLienzo = new System.Windows.Forms.GroupBox();
            this.pnlLienzoPoligono = new WindowsFormsApp2.Ejercicios.Triangulacion.Vistas.clsLienzoPoligono();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.tlpContenedorPrincipal.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.tlpPanelIzquierdo.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.tlpAcciones.SuspendLayout();
            this.grpResultados.SuspendLayout();
            this.tlpResultados.SuspendLayout();
            this.grpDetalle.SuspendLayout();
            this.grpLienzo.SuspendLayout();
            this.SuspendLayout();

            this.tlpContenedorPrincipal.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.tlpContenedorPrincipal.ColumnCount = 2;
            this.tlpContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tlpContenedorPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContenedorPrincipal.Controls.Add(this.pnlEncabezado, 0, 0);
            this.tlpContenedorPrincipal.Controls.Add(this.tlpPanelIzquierdo, 0, 1);
            this.tlpContenedorPrincipal.Controls.Add(this.grpLienzo, 1, 1);
            this.tlpContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.lblTitulo.Text = "Triangulacion de poligonos - Ear Clipping";

            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.lblSubtitulo.Location = new System.Drawing.Point(19, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Terreno irregular dividido en triangulos sin huecos ni solapamientos, verificando que el area se conserve";

            this.tlpPanelIzquierdo.ColumnCount = 1;
            this.tlpPanelIzquierdo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelIzquierdo.Controls.Add(this.grpAcciones, 0, 0);
            this.tlpPanelIzquierdo.Controls.Add(this.lblEstado, 0, 1);
            this.tlpPanelIzquierdo.Controls.Add(this.grpResultados, 0, 2);
            this.tlpPanelIzquierdo.Controls.Add(this.grpDetalle, 0, 3);
            this.tlpPanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPanelIzquierdo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPanelIzquierdo.Name = "tlpPanelIzquierdo";
            this.tlpPanelIzquierdo.RowCount = 4;
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tlpPanelIzquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPanelIzquierdo.TabIndex = 0;

            this.grpAcciones.BackColor = System.Drawing.Color.White;
            this.grpAcciones.Controls.Add(this.tlpAcciones);
            this.grpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAcciones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpAcciones.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpAcciones.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.grpAcciones.TabIndex = 0;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Acciones";

            this.tlpAcciones.ColumnCount = 2;
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcciones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAcciones.Controls.Add(this.btnTriangular, 0, 0);
            this.tlpAcciones.Controls.Add(this.btnCerrarPoligono, 0, 1);
            this.tlpAcciones.Controls.Add(this.btnDeshacer, 1, 1);
            this.tlpAcciones.Controls.Add(this.btnLimpiar, 0, 2);
            this.tlpAcciones.Controls.Add(this.btnCargarEjemplo, 1, 2);
            this.tlpAcciones.Controls.Add(this.chkPasoAPaso, 0, 3);
            this.tlpAcciones.Controls.Add(this.chkAjustarCuadricula, 1, 3);
            this.tlpAcciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAcciones.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tlpAcciones.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.tlpAcciones.Name = "tlpAcciones";
            this.tlpAcciones.RowCount = 4;
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAcciones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAcciones.TabIndex = 0;

            this.tlpAcciones.SetColumnSpan(this.btnTriangular, 2);
            this.btnTriangular.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnTriangular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTriangular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTriangular.FlatAppearance.BorderSize = 0;
            this.btnTriangular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriangular.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnTriangular.ForeColor = System.Drawing.Color.White;
            this.btnTriangular.Name = "btnTriangular";
            this.btnTriangular.TabIndex = 0;
            this.btnTriangular.Text = "&Triangular";
            this.btnTriangular.UseVisualStyleBackColor = false;
            this.btnTriangular.Click += new System.EventHandler(this.btnTriangular_Click);

            this.btnCerrarPoligono.BackColor = System.Drawing.Color.White;
            this.btnCerrarPoligono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarPoligono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrarPoligono.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnCerrarPoligono.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPoligono.Name = "btnCerrarPoligono";
            this.btnCerrarPoligono.TabIndex = 1;
            this.btnCerrarPoligono.Text = "&Cerrar poligono";
            this.btnCerrarPoligono.UseVisualStyleBackColor = false;
            this.btnCerrarPoligono.Click += new System.EventHandler(this.btnCerrarPoligono_Click);

            this.btnDeshacer.BackColor = System.Drawing.Color.White;
            this.btnDeshacer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeshacer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeshacer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.TabIndex = 2;
            this.btnDeshacer.Text = "&Deshacer ultimo";
            this.btnDeshacer.UseVisualStyleBackColor = false;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "&Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.btnCargarEjemplo.BackColor = System.Drawing.Color.White;
            this.btnCargarEjemplo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCargarEjemplo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCargarEjemplo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnCargarEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarEjemplo.Name = "btnCargarEjemplo";
            this.btnCargarEjemplo.TabIndex = 4;
            this.btnCargarEjemplo.Text = "Cargar &ejemplo";
            this.btnCargarEjemplo.UseVisualStyleBackColor = false;
            this.btnCargarEjemplo.Click += new System.EventHandler(this.btnCargarEjemplo_Click);

            this.chkPasoAPaso.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPasoAPaso.AutoSize = true;
            this.chkPasoAPaso.Name = "chkPasoAPaso";
            this.chkPasoAPaso.TabIndex = 5;
            this.chkPasoAPaso.Text = "Animar paso a paso";
            this.chkPasoAPaso.UseVisualStyleBackColor = true;

            this.chkAjustarCuadricula.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkAjustarCuadricula.AutoSize = true;
            this.chkAjustarCuadricula.Checked = true;
            this.chkAjustarCuadricula.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAjustarCuadricula.Name = "chkAjustarCuadricula";
            this.chkAjustarCuadricula.TabIndex = 6;
            this.chkAjustarCuadricula.Text = "Ajustar a cuadricula";
            this.chkAjustarCuadricula.UseVisualStyleBackColor = true;

            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEstado.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.grpResultados.BackColor = System.Drawing.Color.White;
            this.grpResultados.Controls.Add(this.tlpResultados);
            this.grpResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpResultados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpResultados.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpResultados.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.grpResultados.Name = "grpResultados";
            this.grpResultados.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.grpResultados.TabIndex = 2;
            this.grpResultados.TabStop = false;
            this.grpResultados.Text = "Resultados";

            this.tlpResultados.ColumnCount = 2;
            this.tlpResultados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tlpResultados.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResultados.Controls.Add(this.lblEtiquetaVertices, 0, 0);
            this.tlpResultados.Controls.Add(this.lblValorVertices, 1, 0);
            this.tlpResultados.Controls.Add(this.lblEtiquetaTriangulos, 0, 1);
            this.tlpResultados.Controls.Add(this.lblValorTriangulos, 1, 1);
            this.tlpResultados.Controls.Add(this.lblEtiquetaEsperados, 0, 2);
            this.tlpResultados.Controls.Add(this.lblValorEsperados, 1, 2);
            this.tlpResultados.Controls.Add(this.lblEtiquetaAreaPoligono, 0, 3);
            this.tlpResultados.Controls.Add(this.lblValorAreaPoligono, 1, 3);
            this.tlpResultados.Controls.Add(this.lblEtiquetaSumaAreas, 0, 4);
            this.tlpResultados.Controls.Add(this.lblValorSumaAreas, 1, 4);
            this.tlpResultados.Controls.Add(this.lblEtiquetaDiferencia, 0, 5);
            this.tlpResultados.Controls.Add(this.lblValorDiferencia, 1, 5);
            this.tlpResultados.Controls.Add(this.lblEtiquetaVerificacion, 0, 6);
            this.tlpResultados.Controls.Add(this.lblValorVerificacion, 1, 6);
            this.tlpResultados.Controls.Add(this.lblEtiquetaTipo, 0, 7);
            this.tlpResultados.Controls.Add(this.lblValorTipo, 1, 7);
            this.tlpResultados.Controls.Add(this.lblEtiquetaOrientacion, 0, 8);
            this.tlpResultados.Controls.Add(this.lblValorOrientacion, 1, 8);
            this.tlpResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResultados.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.tlpResultados.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.tlpResultados.Name = "tlpResultados";
            this.tlpResultados.RowCount = 10;
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpResultados.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResultados.TabIndex = 0;

            this.lblEtiquetaVertices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVertices.AutoSize = true;
            this.lblEtiquetaVertices.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaVertices.Name = "lblEtiquetaVertices";
            this.lblEtiquetaVertices.Text = "Vertices (n)";
            this.lblValorVertices.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorVertices.AutoSize = true;
            this.lblValorVertices.Name = "lblValorVertices";
            this.lblValorVertices.Text = "-";

            this.lblEtiquetaTriangulos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaTriangulos.AutoSize = true;
            this.lblEtiquetaTriangulos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaTriangulos.Name = "lblEtiquetaTriangulos";
            this.lblEtiquetaTriangulos.Text = "Triangulos obtenidos";
            this.lblValorTriangulos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorTriangulos.AutoSize = true;
            this.lblValorTriangulos.Name = "lblValorTriangulos";
            this.lblValorTriangulos.Text = "-";

            this.lblEtiquetaEsperados.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaEsperados.AutoSize = true;
            this.lblEtiquetaEsperados.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaEsperados.Name = "lblEtiquetaEsperados";
            this.lblEtiquetaEsperados.Text = "Esperados (n - 2)";
            this.lblValorEsperados.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorEsperados.AutoSize = true;
            this.lblValorEsperados.Name = "lblValorEsperados";
            this.lblValorEsperados.Text = "-";

            this.lblEtiquetaAreaPoligono.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaAreaPoligono.AutoSize = true;
            this.lblEtiquetaAreaPoligono.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaAreaPoligono.Name = "lblEtiquetaAreaPoligono";
            this.lblEtiquetaAreaPoligono.Text = "Area poligono";
            this.lblValorAreaPoligono.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorAreaPoligono.AutoSize = true;
            this.lblValorAreaPoligono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblValorAreaPoligono.Name = "lblValorAreaPoligono";
            this.lblValorAreaPoligono.Text = "-";

            this.lblEtiquetaSumaAreas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaSumaAreas.AutoSize = true;
            this.lblEtiquetaSumaAreas.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaSumaAreas.Name = "lblEtiquetaSumaAreas";
            this.lblEtiquetaSumaAreas.Text = "Suma areas triangulos";
            this.lblValorSumaAreas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorSumaAreas.AutoSize = true;
            this.lblValorSumaAreas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblValorSumaAreas.Name = "lblValorSumaAreas";
            this.lblValorSumaAreas.Text = "-";

            this.lblEtiquetaDiferencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaDiferencia.AutoSize = true;
            this.lblEtiquetaDiferencia.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaDiferencia.Name = "lblEtiquetaDiferencia";
            this.lblEtiquetaDiferencia.Text = "Diferencia";
            this.lblValorDiferencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorDiferencia.AutoSize = true;
            this.lblValorDiferencia.Name = "lblValorDiferencia";
            this.lblValorDiferencia.Text = "-";

            this.lblEtiquetaVerificacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaVerificacion.AutoSize = true;
            this.lblEtiquetaVerificacion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblEtiquetaVerificacion.Name = "lblEtiquetaVerificacion";
            this.lblEtiquetaVerificacion.Text = "Verificacion";
            this.lblValorVerificacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorVerificacion.AutoSize = true;
            this.lblValorVerificacion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblValorVerificacion.Name = "lblValorVerificacion";
            this.lblValorVerificacion.Text = "-";

            this.lblEtiquetaTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaTipo.AutoSize = true;
            this.lblEtiquetaTipo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaTipo.Name = "lblEtiquetaTipo";
            this.lblEtiquetaTipo.Text = "Tipo";
            this.lblValorTipo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorTipo.AutoSize = true;
            this.lblValorTipo.Name = "lblValorTipo";
            this.lblValorTipo.Text = "-";

            this.lblEtiquetaOrientacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEtiquetaOrientacion.AutoSize = true;
            this.lblEtiquetaOrientacion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblEtiquetaOrientacion.Name = "lblEtiquetaOrientacion";
            this.lblEtiquetaOrientacion.Text = "Orientacion detectada";
            this.lblValorOrientacion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValorOrientacion.AutoSize = true;
            this.lblValorOrientacion.Name = "lblValorOrientacion";
            this.lblValorOrientacion.Text = "-";

            this.grpDetalle.BackColor = System.Drawing.Color.White;
            this.grpDetalle.Controls.Add(this.txtResultados);
            this.grpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetalle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDetalle.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpDetalle.Margin = new System.Windows.Forms.Padding(0);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Padding = new System.Windows.Forms.Padding(8, 4, 8, 8);
            this.grpDetalle.TabIndex = 3;
            this.grpDetalle.TabStop = false;
            this.grpDetalle.Text = "Detalle de triangulos";

            this.txtResultados.BackColor = System.Drawing.Color.White;
            this.txtResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResultados.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.txtResultados.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.txtResultados.Multiline = true;
            this.txtResultados.Name = "txtResultados";
            this.txtResultados.ReadOnly = true;
            this.txtResultados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultados.TabIndex = 0;

            this.grpLienzo.BackColor = System.Drawing.Color.White;
            this.grpLienzo.Controls.Add(this.pnlLienzoPoligono);
            this.grpLienzo.Controls.Add(this.lblCoordenadas);
            this.grpLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLienzo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpLienzo.ForeColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.grpLienzo.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.grpLienzo.Name = "grpLienzo";
            this.grpLienzo.Padding = new System.Windows.Forms.Padding(8);
            this.grpLienzo.TabIndex = 1;
            this.grpLienzo.TabStop = false;
            this.grpLienzo.Text = "Lienzo (clic izquierdo: agregar vertice, clic derecho: cerrar)";

            this.pnlLienzoPoligono.BackColor = System.Drawing.Color.White;
            this.pnlLienzoPoligono.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnlLienzoPoligono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLienzoPoligono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.pnlLienzoPoligono.Name = "pnlLienzoPoligono";
            this.pnlLienzoPoligono.TabIndex = 0;
            this.pnlLienzoPoligono.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLienzoPoligono_Paint);
            this.pnlLienzoPoligono.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlLienzoPoligono_MouseClick);
            this.pnlLienzoPoligono.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlLienzoPoligono_MouseMove);

            this.lblCoordenadas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCoordenadas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCoordenadas.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(100, 24);
            this.lblCoordenadas.Text = "Cursor: -";
            this.lblCoordenadas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.tmrAnimacion.Interval = 600;
            this.tmrAnimacion.Tick += new System.EventHandler(this.tmrAnimacion_Tick);

            this.AcceptButton = this.btnTriangular;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 246, 249);
            this.ClientSize = new System.Drawing.Size(1200, 760);
            this.Controls.Add(this.tlpContenedorPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MinimumSize = new System.Drawing.Size(980, 740);
            this.Name = "FrmTriangulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triangulacion de poligonos";
            this.Load += new System.EventHandler(this.FrmTriangulacion_Load);
            this.tlpContenedorPrincipal.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.tlpPanelIzquierdo.ResumeLayout(false);
            this.grpAcciones.ResumeLayout(false);
            this.tlpAcciones.ResumeLayout(false);
            this.tlpAcciones.PerformLayout();
            this.grpResultados.ResumeLayout(false);
            this.tlpResultados.ResumeLayout(false);
            this.tlpResultados.PerformLayout();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            this.grpLienzo.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContenedorPrincipal;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TableLayoutPanel tlpPanelIzquierdo;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.TableLayoutPanel tlpAcciones;
        private System.Windows.Forms.Button btnTriangular;
        private System.Windows.Forms.Button btnCerrarPoligono;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCargarEjemplo;
        private System.Windows.Forms.CheckBox chkPasoAPaso;
        private System.Windows.Forms.CheckBox chkAjustarCuadricula;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpResultados;
        private System.Windows.Forms.TableLayoutPanel tlpResultados;
        private System.Windows.Forms.Label lblEtiquetaVertices;
        private System.Windows.Forms.Label lblValorVertices;
        private System.Windows.Forms.Label lblEtiquetaTriangulos;
        private System.Windows.Forms.Label lblValorTriangulos;
        private System.Windows.Forms.Label lblEtiquetaEsperados;
        private System.Windows.Forms.Label lblValorEsperados;
        private System.Windows.Forms.Label lblEtiquetaAreaPoligono;
        private System.Windows.Forms.Label lblValorAreaPoligono;
        private System.Windows.Forms.Label lblEtiquetaSumaAreas;
        private System.Windows.Forms.Label lblValorSumaAreas;
        private System.Windows.Forms.Label lblEtiquetaDiferencia;
        private System.Windows.Forms.Label lblValorDiferencia;
        private System.Windows.Forms.Label lblEtiquetaVerificacion;
        private System.Windows.Forms.Label lblValorVerificacion;
        private System.Windows.Forms.Label lblEtiquetaTipo;
        private System.Windows.Forms.Label lblValorTipo;
        private System.Windows.Forms.Label lblEtiquetaOrientacion;
        private System.Windows.Forms.Label lblValorOrientacion;
        private System.Windows.Forms.GroupBox grpDetalle;
        private System.Windows.Forms.TextBox txtResultados;
        private System.Windows.Forms.GroupBox grpLienzo;
        private WindowsFormsApp2.Ejercicios.Triangulacion.Vistas.clsLienzoPoligono pnlLienzoPoligono;
        private System.Windows.Forms.Label lblCoordenadas;
        private System.Windows.Forms.Timer tmrAnimacion;
    }
}
