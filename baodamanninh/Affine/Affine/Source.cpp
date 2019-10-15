#include<iostream>
#include<string>
using namespace std;
string bangchucai = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
int maso(string bangchucai, char chuoi)
{
	int temp;
	for (int i = 0; i<bangchucai.length(); i++)
	{
		if (chuoi == bangchucai[i]) temp = i;
		break;
	}
	return temp;
}

string mahoa(string bangchucai, string chuoi, int a,int b)
{
	int temp;
	string E = "";
	for (int i = 0; i<chuoi.length(); i++)
	{
		int mso = (bangchucai, chuoi[i]);
		temp = (mso*a+b) % 26;
		E = E + bangchucai[temp];

	}
	return E;
}
string  giaima(string E, int a,int b)
{
	int temp;
	string D = "";
	for (int i = 0; i<E.length(); i++)
	{
		int mso = (bangchucai, E[i]);
		temp = (mso - k) % 26;
		D = D + bangchucai[temp];

	}
	return D;
}
int main()
{
	string s, E, D;
	int a,b;
	cout << "nhp vao chuoi ma hoa: ";
	getline(cin, s);
	cout << "\n nhap vao a: ";
	cin >> a;
	cout << "\n nhap vao b: ";
	cin >> b;
	cout << "\n chuoi sau khi ma hoa la: ";
	E = mahoa(bangchucai, s, a,b);
	cout << E;
	cout << "\n chuoi giai ma la: ";
	cout << giaima(E, 6);
	system("pause");

}
