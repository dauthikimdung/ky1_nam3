#include<iostream>
using namespace std;
int a[100];
int n;
void Input(void) {
	freopen("input.IN", "r", stdin);
	cin >> n;
	cout << "So phan tu cua mang: " << n << endl;
	// khoi tao mang A
	for (int i = 1; i <= n; i++) 
	{
			cin >> a[i];
	}
}
int main() {
	
Input();
	// s la diem dau, e la diem cuoi,s1 diem tam
	// khoi tao
	int maxs = a[1]; // maxs la maxs hien tai
	int maxe = a[1]; // maxe la max moi tinh
	
	int s = 1, e = 1;
	int s1 = 1;
	for (int i = 2; i <= n; i++)
	{
		if (maxe > 0) maxe = maxe + a[i];// neu lon hon 0 thi cong vao maxe
		else neu am 
		{
			maxe = a[i];//thi gan lai maxe cho phan tu a[i]
			s1 = i;// bien tam s1 luu diem dau tien
		}
		if (maxe > maxs) // tim duoc max lon hon thi gan vao maxs
		{
			maxs = maxe;
			e = i;// e gan cho diem cuoi
			s = s1;// s1 gan cho diem dau
		}
	}
	cout << s << endl << e<< endl << maxs << endl; // in tu diem dau-> cuoi va max

	system("pause");
}
