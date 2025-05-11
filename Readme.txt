Program pozwala na wielowątkowe mnożenie macerzy o zadanej wielkości oraz losowych wartościach liczbowych.
Głównym celem programu jest zbadanie różnic między mnożeniem metodami Parallel oraz Thread.
Pragram realizuje zadanie na 4.0.

Program nie posiada interfejsu graicznego, po uruchomieniu uruchamia testy dla zadanych parametrów oraz eksportuje dane do plików csv.

Opis klas:
Matrix - klasa przechwująca macierz, posiada:
        public int Rows { get; private set; } - ilość wierszy
        public int Cols { get; private set; } - ilość kolumn
        public float[,] Values; - wartości liczbowe macierzy
	
	Dodatkowo klasa posiada metodę FillWithRandomValues(), która wypełnia macierz losowymi liczbami (jeat uruchamiana w knstruktorze)

Multiplication - klasa odpowiadająca za mnożenie macieży zawira zmienną NumThreads, która określa ilość wątków używanych podczas obliczeń.
	MultiplyParallel(Matrix A, Matrix B) - mnożenie macierzy za pomocą Parallel
	MultiplyThread(Matrix A, Matrix B)  - mnożenie macierzy za pomocą Thread

Tests - odpowiada za wykonanie testów mnożenia macierzy, jej zmienne to:
        int[] Threads - dla jakich ilości wątków zostaną wykonane testy
        int[] Sizes - dla jakich rozmiarów macierzy kwadratowych zostaną przeprowadzone testy
        long[,] Results; - wyniki czasu dla powyższych warunków

	DoTests(int NumTests, TestType type, string FilePath) odpwiada za wykonanie testów. 
	NumTests to ilość powtórzeń dla każdych warunków, type pozwala wybrać jaką metodą będą mnożone macierze, 
	a FilePath określa miejsce zapisu pliku csv.

Wyniki dla Parallel (kolejno dla 1, 2, 3, 4 wątków):

Dla rozmiaru 100x100: 265,58,157,42
Dla rozmiaru 220x220: 526,134,111,101
Dla rozmiaru 500x500: 2708,1737,1392,1205

Wyniki dla Thread (kolejno dla 1, 2, 3, 4 wątków):

Dla rozmiaru 100x100: 39,56,54,72
Dla rozmiaru 220x220: 275,193,186,179
Dla rozmiaru 500x500: 2815,1872,1628,1433

Wnioski:
Thread pozwoliło uzyskać lepsze wyniki dla dużych macieży oraz większych ilości wątków, chociaż pierwotna implementacja tej funkcji działała zdecydowanie dłużej niż parallel



