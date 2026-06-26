using System;
using System.Drawing;
using System.Windows.Forms;

partial class _FrmDataViewer
{
    private void InitializeComponent()
    {
        this.BackColor     = BG_DARK;
        this.ForeColor     = C_TEXT;
        this.Text          = "그래프 데이터 조회";
        this.Size          = new Size(1440, 940);
        this.MinimumSize   = new Size(1100, 740);
        this.Font          = new Font("맑은 고딕", 11f);
        this.StartPosition = FormStartPosition.CenterParent;

        // ══════════════════════════════════════════════════════════
        // 좌측 패널 (파일 목록)
        // ══════════════════════════════════════════════════════════
        var panelLeft = new Panel
        {
            Dock      = DockStyle.Left,
            Width     = 240,
            BackColor = BG_PANEL,
        };

        // 날짜 선택 고정 헤더
        var panelLeftTop = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 98,
            BackColor = BG_PANEL,
            Padding   = new Padding(8, 6, 8, 0),
        };

        var lblDate = MakeLabel("■ 날짜 선택", 8, 6, 220, 22, bold: true);
        lblDate.ForeColor = Color.FromArgb(99, 202, 255);

        dtpDate = new DateTimePicker
        {
            Location  = new Point(8, 32),
            Width     = 218,
            Format    = DateTimePickerFormat.Short,
            Font      = new Font("맑은 고딕", 11f),
            CalendarForeColor       = C_TEXT,
            CalendarMonthBackground = BG_CARD,
        };
        dtpDate.ValueChanged += DtpDate_ValueChanged;

        var lblFiles = MakeLabel("■ 파일 목록  (Ctrl = 오버레이)", 8, 68, 220, 20, bold: true);
        lblFiles.ForeColor = Color.FromArgb(99, 202, 255);

        panelLeftTop.Controls.AddRange(new Control[] { lblDate, dtpDate, lblFiles });

        // 파일 리스트 — Fill로 남은 공간 전부 사용
        lbFiles = new ListBox
        {
            Dock          = DockStyle.Fill,
            BackColor     = BG_DARK,
            ForeColor     = C_TEXT,
            SelectionMode = SelectionMode.MultiExtended,
            BorderStyle   = BorderStyle.None,
            Font          = new Font("맑은 고딕", 10f),
            ItemHeight    = 24,
        };
        lbFiles.SelectedIndexChanged += LbFiles_SelectedIndexChanged;

        panelLeft.Controls.Add(lbFiles);       // Fill 먼저
        panelLeft.Controls.Add(panelLeftTop);  // Top 나중에 (Dock 순서)

        // ══════════════════════════════════════════════════════════
        // 우측 메인 패널
        // ══════════════════════════════════════════════════════════
        var panelRight = new Panel
        {
            Dock      = DockStyle.Fill,
            BackColor = BG_DARK,
            Padding   = new Padding(4, 4, 4, 4)
        };

        // ── 상단 툴바 ─────────────────────────────────────────────
        var toolBar = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 48,
            BackColor = BG_PANEL,
        };

        int bx = 6;
        var btnScaleApply = MakeToolBtn("스케일 적용", bx, 8); bx += 104;
        var btnScaleAuto  = MakeToolBtn("자동 맞춤",   bx, 8); bx += 94;
        var btnScaleReset = MakeToolBtn("기본 스케일", bx, 8); bx += 104;

        var sepL1 = new Label { Text = "|", Location = new Point(bx, 8),
            AutoSize = true, ForeColor = C_MUTED, Font = new Font("맑은 고딕", 11f) }; bx += 16;

        btnMarkA = MakeToolBtn("▶ 마커 A", bx, 8, 84); bx += 88;
        btnMarkB = MakeToolBtn("▶ 마커 B", bx, 8, 84); bx += 88;

        var sepL2 = new Label { Text = "|", Location = new Point(bx, 8),
            AutoSize = true, ForeColor = C_MUTED, Font = new Font("맑은 고딕", 11f) }; bx += 16;

        var btnSaveImage = MakeToolBtn("이미지 저장",  bx, 8, 100); bx += 104;
        var btnExportCsv = MakeToolBtn("CSV 내보내기", bx, 8, 106); bx += 110;

        // 스케일 입력 (툴바 우측)
        var lblSX  = MakeLabel("X:", bx + 8,  16, 18, 20);
        txXMin = MakeNumBox(bx + 26,  8, 52, "-2.0");
        var lbl1   = MakeLabel("~", bx + 80,  16, 12, 20);
        txXMax = MakeNumBox(bx + 92,  8, 52, "2.0");
        var lblSY  = MakeLabel("Y:", bx + 152, 16, 18, 20);
        txYMin = MakeNumBox(bx + 170, 8, 58, "-15.0");
        var lbl2   = MakeLabel("~", bx + 230, 16, 12, 20);
        txYMax = MakeNumBox(bx + 242, 8, 52, "15.0");

        btnScaleApply.Click += BtnScaleApply_Click;
        btnScaleAuto.Click  += BtnScaleAuto_Click;
        btnScaleReset.Click += BtnScaleReset_Click;
        btnMarkA.Click      += BtnMarkA_Click;
        btnMarkB.Click      += BtnMarkB_Click;
        btnSaveImage.Click  += BtnSaveImage_Click;
        btnExportCsv.Click  += BtnExportCsv_Click;

        toolBar.Controls.AddRange(new Control[]
        {
            btnScaleApply, btnScaleAuto, btnScaleReset, sepL1,
            btnMarkA, btnMarkB, sepL2,
            btnSaveImage, btnExportCsv,
            lblSX, txXMin, lbl1, txXMax,
            lblSY, txYMin, lbl2, txYMax,
        });

        // ── 그래프 ────────────────────────────────────────────────
        zgGraph = new ZedGraph.ZedGraphControl
        {
            Dock      = DockStyle.Top,
            Height    = 540,
            BackColor = BG_DARK,
        };

        // ── 통계 / 마커 패널 ──────────────────────────────────────
        var panelStats = new Panel
        {
            Dock      = DockStyle.Top,
            Height    = 130,
            BackColor = BG_PANEL,
            Padding   = new Padding(8, 4, 8, 4),
        };

        // 메타 정보 (한 줄)
        lblStatMeta = MakeLabel("파일을 선택하세요", 8, 4, 900, 22);
        lblStatMeta.Font = new Font("맑은 고딕", 11f);

        // 전방 / 후방 (한 줄씩)
        lblStatFwd = MakeLabel("전방: —", 8, 30, 750, 24);
        lblStatFwd.Font      = new Font("맑은 고딕", 12f, FontStyle.Bold);
        lblStatFwd.ForeColor = C_FWD;

        lblStatBwd = MakeLabel("후방: —", 8, 56, 750, 24);
        lblStatBwd.Font      = new Font("맑은 고딕", 12f, FontStyle.Bold);
        lblStatBwd.ForeColor = C_BWD;

        // 마커 / 커서 (한 줄)
        lblMarkerStat = MakeLabel("마커: A·B 버튼으로 구간 선택", 8, 84, 600, 22);
        lblMarkerStat.Font      = new Font("맑은 고딕", 10f);
        lblMarkerStat.ForeColor = C_MARK_A;

        lblCursor = MakeLabel("X: —    Y: —", 620, 84, 320, 22);
        lblCursor.Font      = new Font("맑은 고딕", 10f);
        lblCursor.ForeColor = C_MUTED;

        // 유격 검사값 (우측)
        lblStatGap = MakeLabel("유격 검사값", 940, 4, 200, 22);
        lblStatGap.Font      = new Font("맑은 고딕", 10f);
        lblStatGap.ForeColor = C_MUTED;
        lblStatGap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        lblStatGapVal = MakeLabel("—", 900, 24, 280, 82);
        lblStatGapVal.Font      = new Font("맑은 고딕", 40f, FontStyle.Bold);
        lblStatGapVal.ForeColor = C_MUTED;
        lblStatGapVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        panelStats.Controls.AddRange(new Control[]
        {
            lblStatMeta, lblStatFwd, lblStatBwd, lblMarkerStat, lblCursor,
            lblStatGap, lblStatGapVal,
        });

        // ── 데이터 그리드 ─────────────────────────────────────────
        dgData = new DataGridView
        {
            Dock                = DockStyle.Fill,
            BackgroundColor     = BG_DARK,
            GridColor           = C_GRID,
            BorderStyle         = BorderStyle.None,
            RowHeadersVisible   = false,
            AllowUserToAddRows  = false,
            ReadOnly            = true,
            Font                = new Font("맑은 고딕", 10f),
            SelectionMode       = DataGridViewSelectionMode.FullRowSelect,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        };
        dgData.DefaultCellStyle.BackColor          = BG_DARK;
        dgData.DefaultCellStyle.ForeColor          = C_TEXT;
        dgData.DefaultCellStyle.SelectionBackColor = C_BLUE;
        dgData.DefaultCellStyle.SelectionForeColor = Color.White;
        dgData.ColumnHeadersDefaultCellStyle.BackColor = BG_PANEL;
        dgData.ColumnHeadersDefaultCellStyle.ForeColor = C_TEXT;
        dgData.ColumnHeadersDefaultCellStyle.Font  = new Font("맑은 고딕", 11f, FontStyle.Bold);
        dgData.ColumnHeadersHeight         = 32;
        dgData.EnableHeadersVisualStyles   = false;
        dgData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(20, 30, 45);
        dgData.RowTemplate.Height          = 26;

        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "측정시각" });
        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBC",   HeaderText = "바코드"   });
        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDir",  HeaderText = "방향",  FillWeight = 40 });
        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdx",  HeaderText = "인덱스", FillWeight = 40 });
        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colX",    HeaderText = "X (mm)"   });
        dgData.Columns.Add(new DataGridViewTextBoxColumn { Name = "colY",    HeaderText = "Y (하중)"  });

        dgData.CellFormatting += (ss, ev) =>
        {
            if (ev.ColumnIndex == dgData.Columns["colDir"].Index && ev.Value != null)
                ev.CellStyle.ForeColor = ev.Value.ToString() == "전방" ? C_FWD : C_BWD;
        };

        panelRight.Controls.Add(dgData);
        panelRight.Controls.Add(panelStats);
        panelRight.Controls.Add(zgGraph);
        panelRight.Controls.Add(toolBar);

        this.Controls.Add(panelRight);
        this.Controls.Add(panelLeft);
    }

    // ── 헬퍼 ──────────────────────────────────────────────────────
    private Label MakeLabel(string text, int x, int y, int w, int h, bool bold = false)
    {
        return new Label
        {
            Text      = text,
            Location  = new Point(x, y),
            Size      = new Size(w, h),
            ForeColor = C_TEXT,
            Font      = bold
                ? new Font("맑은 고딕", 11f, FontStyle.Bold)
                : new Font("맑은 고딕", 11f),
        };
    }

    private Button MakeToolBtn(string text, int x, int y, int w = 96)
    {
        var btn = new Button
        {
            Text      = text,
            Location  = new Point(x, y),
            Size      = new Size(w, 32),
            BackColor = BG_DARK,
            ForeColor = C_TEXT,
            FlatStyle = FlatStyle.Flat,
            Font      = new Font("맑은 고딕", 10f),
        };
        btn.FlatAppearance.BorderColor = C_GRID;
        return btn;
    }

    private TextBox MakeNumBox(int x, int y, int w, string def)
    {
        return new TextBox
        {
            Location    = new Point(x, y),
            Size        = new Size(w, 28),
            Text        = def,
            BackColor   = BG_DARK,
            ForeColor   = C_TEXT,
            BorderStyle = BorderStyle.FixedSingle,
            Font        = new Font("Consolas", 10f),
            TextAlign   = HorizontalAlignment.Center,
        };
    }
}
