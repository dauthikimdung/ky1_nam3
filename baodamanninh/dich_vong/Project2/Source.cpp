#include<iostream>
#include<string>
using namespace std;
string bangchucai = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
int maso(string bangchucai, char chuoi)
{
	int temp;
	for (int i = 0; i<bangchucai.length(); i++)
	{
		if (chuoi == bangchucai[i])
		{
			temp = i;
			break;
		}
	}
	return temp;
}

string mahoavong(string bangchucai, string chuoi, int k)
{
	int temp;
	string E="";
	for (int i = 0; i<chuoi.length(); i++)
	{
		int mso = maso(bangchucai, chuoi[i]);
		temp = (mso + k) % 26;
		E=E+bangchucai[temp];

	}
	return E;
}
string  giaima(string E, int k)
{
	int temp;
	string D="";
	for (int i = 0; i<E.length(); i++)
	{
		int mso = (bangchucai, E[i]);
		if (mso -k< 0) temp = (26 + mso-k) % 26;
		else
		temp = (mso - k) % 26;
		D = D+bangchucai[temp];

	}
	return D;
}
int main()
{
	string s,E,D;
	int k;
	cout << "nhp vao chuoi ma hoa: " ;
	getline(cin, s);
	cout << "\n nhap vao khoa k: ";
	cin >> k;
	cout << "\n chuoi sau khi ma hoa la: ";
	E=mahoavong(bangchucai,s,k);
	cout<<E;
	cout << "\n chuoi giai ma la: ";
	cout<<giaima(E,6);
	system("pause");

}
