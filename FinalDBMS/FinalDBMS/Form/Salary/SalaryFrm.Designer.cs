
namespace FinalDBMS
{
    partial class SalaryFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalaryFrm));
            this.dataGridViewShow = new System.Windows.Forms.DataGridView();
            this.btnWord = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnShowFull = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShow
            // 
            this.dataGridViewShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShow.Location = new System.Drawing.Point(17, 139);
            this.dataGridViewShow.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.RowHeadersWidth = 62;
            this.dataGridViewShow.RowTemplate.Height = 28;
            this.dataGridViewShow.Size = new System.Drawing.Size(1040, 411);
            this.dataGridViewShow.TabIndex = 0;
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.White;
            this.btnWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnWord.Location = new System.Drawing.Point(17, 109);
            this.btnWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(128, 26);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "In ra file WORD";
            this.btnWord.UseVisualStyleBackColor = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label6.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(313, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(453, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "BẢNG LƯƠNG NHÂN VIÊN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label1.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(604, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 10);
            this.label1.TabIndex = 13;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label2.Location = new System.Drawing.Point(605, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tháng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbMonth.Location = new System.Drawing.Point(665, 97);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(88, 21);
            this.cbMonth.TabIndex = 15;
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040",
            "2041",
            "2042",
            "2043",
            "2044",
            "2045",
            "2046",
            "2047",
            "2048",
            "2049",
            "2050",
            "2051",
            "2052",
            "2053",
            "2054",
            "2055",
            "2056",
            "2057",
            "2058",
            "2059",
            "2060",
            "2061",
            "2062",
            "2063",
            "2064",
            "2065",
            "2066",
            "2067",
            "2068",
            "2069",
            "2070",
            "2071",
            "2072",
            "2073",
            "2074",
            "2075",
            "2076",
            "2077",
            "2078",
            "2079",
            "2080",
            "2081",
            "2082",
            "2083",
            "2084",
            "2085",
            "2086",
            "2087",
            "2088",
            "2089",
            "2090",
            "2091",
            "2092",
            "2093",
            "2094",
            "2095",
            "2096",
            "2097",
            "2098",
            "2099",
            "2100",
            "2101",
            "2102",
            "2103",
            "2104",
            "2105",
            "2106",
            "2107",
            "2108",
            "2109",
            "2110",
            "2111",
            "2112",
            "2113",
            "2114",
            "2115",
            "2116",
            "2117",
            "2118",
            "2119",
            "2120",
            "2121",
            "2122",
            "2123",
            "2124",
            "2125",
            "2126",
            "2127",
            "2128",
            "2129",
            "2130",
            "2131",
            "2132",
            "2133",
            "2134",
            "2135",
            "2136",
            "2137",
            "2138",
            "2139",
            "2140",
            "2141",
            "2142",
            "2143",
            "2144",
            "2145",
            "2146",
            "2147",
            "2148",
            "2149",
            "2150",
            "2151",
            "2152",
            "2153",
            "2154",
            "2155",
            "2156",
            "2157",
            "2158",
            "2159",
            "2160",
            "2161",
            "2162",
            "2163",
            "2164",
            "2165",
            "2166",
            "2167",
            "2168",
            "2169",
            "2170",
            "2171",
            "2172",
            "2173",
            "2174",
            "2175",
            "2176",
            "2177",
            "2178",
            "2179",
            "2180",
            "2181",
            "2182",
            "2183",
            "2184",
            "2185",
            "2186",
            "2187",
            "2188",
            "2189",
            "2190",
            "2191",
            "2192",
            "2193",
            "2194",
            "2195",
            "2196",
            "2197",
            "2198",
            "2199",
            "2200",
            "2201",
            "2202",
            "2203",
            "2204",
            "2205",
            "2206",
            "2207",
            "2208",
            "2209",
            "2210",
            "2211",
            "2212",
            "2213",
            "2214",
            "2215",
            "2216",
            "2217",
            "2218",
            "2219",
            "2220",
            "2221",
            "2222",
            "2223",
            "2224",
            "2225",
            "2226",
            "2227",
            "2228",
            "2229",
            "2230",
            "2231",
            "2232",
            "2233",
            "2234",
            "2235",
            "2236",
            "2237",
            "2238",
            "2239",
            "2240",
            "2241",
            "2242",
            "2243",
            "2244",
            "2245",
            "2246",
            "2247",
            "2248",
            "2249",
            "2250",
            "2251",
            "2252",
            "2253",
            "2254",
            "2255",
            "2256",
            "2257",
            "2258",
            "2259",
            "2260",
            "2261",
            "2262",
            "2263",
            "2264",
            "2265",
            "2266",
            "2267",
            "2268",
            "2269",
            "2270",
            "2271",
            "2272",
            "2273",
            "2274",
            "2275",
            "2276",
            "2277",
            "2278",
            "2279",
            "2280",
            "2281",
            "2282",
            "2283",
            "2284",
            "2285",
            "2286",
            "2287",
            "2288",
            "2289",
            "2290",
            "2291",
            "2292",
            "2293",
            "2294",
            "2295",
            "2296",
            "2297",
            "2298",
            "2299",
            "2300",
            "2301",
            "2302",
            "2303",
            "2304",
            "2305",
            "2306",
            "2307",
            "2308",
            "2309",
            "2310",
            "2311",
            "2312",
            "2313",
            "2314",
            "2315",
            "2316",
            "2317",
            "2318",
            "2319",
            "2320",
            "2321",
            "2322",
            "2323",
            "2324",
            "2325",
            "2326",
            "2327",
            "2328",
            "2329",
            "2330",
            "2331",
            "2332",
            "2333",
            "2334",
            "2335",
            "2336",
            "2337",
            "2338",
            "2339",
            "2340",
            "2341",
            "2342",
            "2343",
            "2344",
            "2345",
            "2346",
            "2347",
            "2348",
            "2349",
            "2350",
            "2351",
            "2352",
            "2353",
            "2354",
            "2355",
            "2356",
            "2357",
            "2358",
            "2359",
            "2360",
            "2361",
            "2362",
            "2363",
            "2364",
            "2365",
            "2366",
            "2367",
            "2368",
            "2369",
            "2370",
            "2371",
            "2372",
            "2373",
            "2374",
            "2375",
            "2376",
            "2377",
            "2378",
            "2379",
            "2380",
            "2381",
            "2382",
            "2383",
            "2384",
            "2385",
            "2386",
            "2387",
            "2388",
            "2389",
            "2390",
            "2391",
            "2392",
            "2393",
            "2394",
            "2395",
            "2396",
            "2397",
            "2398",
            "2399",
            "2400",
            "2401",
            "2402",
            "2403",
            "2404",
            "2405",
            "2406",
            "2407",
            "2408",
            "2409",
            "2410",
            "2411",
            "2412",
            "2413",
            "2414",
            "2415",
            "2416",
            "2417",
            "2418",
            "2419",
            "2420",
            "2421",
            "2422",
            "2423",
            "2424",
            "2425",
            "2426",
            "2427",
            "2428",
            "2429",
            "2430",
            "2431",
            "2432",
            "2433",
            "2434",
            "2435",
            "2436",
            "2437",
            "2438",
            "2439",
            "2440",
            "2441",
            "2442",
            "2443",
            "2444",
            "2445",
            "2446",
            "2447",
            "2448",
            "2449",
            "2450",
            "2451",
            "2452",
            "2453",
            "2454",
            "2455",
            "2456",
            "2457",
            "2458",
            "2459",
            "2460",
            "2461",
            "2462",
            "2463",
            "2464",
            "2465",
            "2466",
            "2467",
            "2468",
            "2469",
            "2470",
            "2471",
            "2472",
            "2473",
            "2474",
            "2475",
            "2476",
            "2477",
            "2478",
            "2479",
            "2480",
            "2481",
            "2482",
            "2483",
            "2484",
            "2485",
            "2486",
            "2487",
            "2488",
            "2489",
            "2490",
            "2491",
            "2492",
            "2493",
            "2494",
            "2495",
            "2496",
            "2497",
            "2498",
            "2499",
            "2500"});
            this.cbYear.Location = new System.Drawing.Point(823, 97);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(125, 21);
            this.cbYear.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label3.Location = new System.Drawing.Point(763, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Năm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnFind.Location = new System.Drawing.Point(969, 93);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(88, 26);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnShowFull
            // 
            this.btnShowFull.BackColor = System.Drawing.Color.White;
            this.btnShowFull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnShowFull.Location = new System.Drawing.Point(149, 109);
            this.btnShowFull.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowFull.Name = "btnShowFull";
            this.btnShowFull.Size = new System.Drawing.Size(88, 26);
            this.btnShowFull.TabIndex = 19;
            this.btnShowFull.Text = "Show Full";
            this.btnShowFull.UseVisualStyleBackColor = false;
            this.btnShowFull.Click += new System.EventHandler(this.btnShowFull_Click);
            // 
            // SalaryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1068, 561);
            this.Controls.Add(this.btnShowFull);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.dataGridViewShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SalaryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary";
            this.Load += new System.EventHandler(this.SalaryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShow;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnShowFull;
    }
}