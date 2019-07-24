#include<iostream>
#include<stdio.h>
#define Max 100
using namespace std;
int C[Max], w[Max];
int MaxL[Max][Max] = { 0 };
int Bag(int sodv, int maxW) {
	for (int l = 0; l <= maxW; l++) {
		MaxL[0][l] = 0;
	}
	for (int i=1; i <= sodv; i++) {
		MaxL[i][0] = 0;
	}
	for (int i = 1; i <= sodv; i++) {
		for (int L = 0; L <= maxW; L++) {
			if (w[i] <= L)
				if (C[i] + MaxL[i - 1][L - w[i]]>MaxL[i - 1][L])
					MaxL[i][L] = C[i] + MaxL[i - 1][L - w[i]];
				else
					MaxL[i][L] = MaxL[i - 1][L];
			else
				MaxL[i][L] = MaxL[i - 1][L];
		}
	}
	cout << MaxL[sodv][maxW];
	return MaxL[sodv][maxW];
}
int main() {
	int sodv, maxW;
	cout << "so do vat :";
	cin >> sodv;
	cout << "trong luong toi da: ";
	cin >> maxW;
	for (int i = 0; i < sodv; i++) {
		cout << "trong luong " << i + 1 << ": ";
		cin >> w[i];
		cout << "gia tri " << i + 1 << ": ";
		cin >> C[i];
	}
	Bag(sodv, maxW);
	system("pause");
	return 0;
}