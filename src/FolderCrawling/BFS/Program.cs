using System.Data;

// namespace declaration
namespace BFS {
      
    // Class declaration
    class usingBFS {
        static void useBFS(string file, string[] folder) {
            if ( folder.Length > 0 ) {
                if ( folder[0].Split('\\').Last() == "System Volume Information") {
                    int indexToRemove = 0;
                    folder = folder.Where((source, index) =>index != indexToRemove).ToArray();
                    useBFS(file, folder);
                } else {
                    string[] folderTemp = Directory.GetDirectories(folder[0]);
                    string[] filesTemp = Directory.GetFiles(folder[0]);

                    bool found = false; //buat cek status jika file sudah ditemukan atau tidak
                    int i = 0;
                    while ( !found && i < filesTemp.Length) { //Cek dulu semua file yang ada pada awalnya
                        if ( file  == filesTemp[i].Split('\\').Last()){
                            found = true;
                        } else {
                            Console.WriteLine(filesTemp[i]);
                            i++;
                        }
                    }

                    if ( !found ) {
                        foreach ( string fullpath in folderTemp ) { 
                            Console.WriteLine(fullpath);
                        }
                        int indexToRemove = 0;
                        folder = folder.Concat(folderTemp).ToArray();
                        folder = folder.Where((source, index) =>index != indexToRemove).ToArray();

                        useBFS(file, folder);
                    } else {
                        Console.WriteLine("File Telah Ditemukan");
                        Console.WriteLine(filesTemp[i]);
                        return;
                    }
                }
            } else {
                Console.WriteLine("File Tidak Ditemukan");
                return;
            }
        }

        static void firstCheck(string file, string Filetujuan) {
            //string[] path = {}; //buat array proses yang akan dilalui nantinya
            string[] files = Directory.GetFiles(Filetujuan); //buat array file
            bool found = false; //buat cek status jika file sudah ditemukan atau tidak

            //Proses Awal: Mengecek terlebih dahulu semua file yang ada
            int i = 0;
            while ( !found && i < files.Length) { 
                if ( file  == files[i].Split('\\').Last()){
                    found = true;
                } else {
                    Console.WriteLine(files[i]);
                    i++;
                }
            }

            if ( !found ) { //Jika tidak ditemukan file, akan mengecek folder yang ada didalamnya untuk disimpan
                string[] folder = Directory.GetDirectories(Filetujuan, "*.", SearchOption.TopDirectoryOnly); //buat array folder
                foreach ( string fullpath in folder ) { //Menampilkan folder yang ada di dalamnya
                    Console.WriteLine(fullpath);
                }
                useBFS(file, folder);
            } else {
                Console.WriteLine("File Telah Ditemukan");
                Console.WriteLine(files[i]);
            }
        }

        // Main Method
        static void Main(string[] args) {
            int pilihan;
            string namaFile, Filetujuan;
            Boolean isInput = false;

            while ( !isInput ) {
                Console.WriteLine("Silakan pilih titik awal pencarian (pilih berdasarkan angka)");
                Console.WriteLine("1 - Disk C");
                Console.WriteLine("2 - Disk D");
                Console.WriteLine("3 - Disk E");
    
                pilihan = Convert.ToInt32(Console.ReadLine());
                if ( pilihan == 1 ) {
                    Filetujuan = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + @"C:\";
                    bool isDirExist = Directory.Exists(Filetujuan);
                    isInput = true;
                    if ( isDirExist ) {
                        Console.WriteLine("Directory Exists");
                        Console.WriteLine("Silakan ketik nama file yang akan dicari");
                        namaFile = Console.ReadLine();
                        firstCheck(namaFile, Filetujuan);
                    } else {
                        Console.WriteLine("Directory not Exists");
                    }
                } else if ( pilihan == 2 ) {
                    Filetujuan = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + @"D:\";
                    bool isDirExist = Directory.Exists(Filetujuan);
                    isInput = true;
                    if ( isDirExist ) {
                        Console.WriteLine("Directory Exists");
                        Console.WriteLine("Silakan ketik nama file yang akan dicari");
                        namaFile = Console.ReadLine();
                        firstCheck(namaFile, Filetujuan);
                    } else {
                        Console.WriteLine("Directory not Exists");
                    }
                } else if ( pilihan == 3 ) {
                    Filetujuan = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + @"E:\";
                    bool isDirExist = Directory.Exists(Filetujuan);
                    isInput = true;
                    if ( isDirExist ) {
                        Console.WriteLine("Directory Exists");
                        Console.WriteLine("Silakan ketik nama file yang akan dicari");
                        namaFile = Console.ReadLine();
                        firstCheck(namaFile, Filetujuan);
                    } else {
                        Console.WriteLine("Directory not Exists");
                    }
                } else {
                    Console.WriteLine("Input Anda Salah!");
                }
            }
        }
    }
}