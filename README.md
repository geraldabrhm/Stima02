# Tugas Besar 1 IF2211 Strategi Algoritma

Kelompok:

1. Gerald Abraham Sianturi (NIM : 13520138)
2. Ikmal Alfaozi (NIM : 13520125)
3. Shadiq Harwiz (NIM : 13520038)

Repository ini dibuat dalam rangka memenuhi Tugas Besar 2 IF2211 Strategi Algoritma 2021/2022. Repository ini berisi aplikasi GUI sederhana yang memodelkan fitur dari file explorer pada sistem operasi, yang pada tugas ini disebut dengan Folder Crawling. Aplikasi ini memanfaatkan algoritma Breadth First Search (BFS) dan Depth First Search (DFS) untuk menelusuri folder-folder yang ada pada direktori untuk mendapatkan direktori yang Anda inginkan. Selain itu, aplikasi ini juga dapat memvisualisasikan hasil dari pencarian folder tersebut dalam bentuk pohon.

## Penjelasan Singkat Algoritma BFS dan DFS yang digunakan

Pada directory yang dipilih, semua subdirectory (folder) dan file yang ada di directory tersebut disimpan namanya dalam bentuk list. Kemudian, pada file-file di directory tersebut diperiksa apakah namanya sama dengan file yang dicari. Jika file ditemukan, program akan menampilkan path dari folder parent-nya. Sebaliknya, jika file tidak ditemukan, program akan memeriksa folder-folder berikutnya yangng belum ditelusuri.belum ditelusuri.

Berikut adalah langkah-langkahnya :

1. Dilakukan pengambilan nama directory dari directory yang dipilih oleh pengguna beserta nama file dari isian pengguna.
2. Nama directory dan file yang ditemukan dijadikan parameter dalam metode DFS dan BFS.
3. Pada metode DFS dan BFS, dilakukan pembentukan graf yang terdiri dari node dan edge terus dibentuk seiring pencarian file.
    - Pada kasus find all occurrences Semua folder ditelusuri, dan setiap file yang sesuai disimpan path-nya dalam sebuah list.
    - Pada kasus find first occurrence ketika file pertama ditemukan, pencarian dihentikan pada level tersebut.

## Requirement

## How to Run
1. Buka folder `bin`
2. Klik salah satu diantara `Folder Crawling.exe` dan `Folder Crawling.msi`
3. Lakukan proses instalasi hingga selesai
4. Aplikasi dapat digunakan
