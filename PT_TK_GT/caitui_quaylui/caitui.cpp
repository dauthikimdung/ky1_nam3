//DAU THI KIM DUNG
#include <bits/stdc++.h>
#define f first
#define s second
#define maxn 2000
using namespace std;
int n, b, d[maxn], kq, t[maxn];
pair <int, int> a[maxn];

void Try(int x, int sumgt, int sumtl)			

{
	if (x>n)									// khi da Try het n vat
	{
		if (sumgt>kq)								// khi tong gia tri sumgt cua cach chon hien tai lon hon ket qua toi uu cac cach chon truoc do
		{
			kq = sumgt;
			for (int i = 1; i <= n; i++)
				t[i] = d[i];
			return;
		}
	}
	else
	{
		if (!d[x] && sumtl + a[x].s <= b)				// neu vat thu x chua duoc chon va tong trong luong hien tai sumtl voi trong luong cua vat thu x khong qua trong luong toi da cua tui la b
		{
			d[x] = 1;									// danh dau vat thu x da duoc chon
			Try(x + 1, sumgt + a[x].f, sumtl + a[x].s);	    // Try de quy vat tiep theo x+1 voi tong gia tri moi la sumgt+a[x].f va tong trong luong moi la sumtl+a[x].s khi chon vat thu x
			d[x] = 0;
		}
		Try(x + 1, sumgt, sumtl);						// Try de quy vat tiep theo x+1 khi khong chon vat thu x nen sumgt va sumtl giu nguyen gia tri
	}
}

int main()
{
	freopen("input.txt", "r", stdin);
	cin >> n >> b;						// doc du lieu dau vao, n la so luong vat va b la m toi da cua cai tui
	for (int i = 1; i <= n; i++)
		cin >> a[i].s >> a[i].f;		// doc du lieu ve n vat
	kq = 0;
	for (int i = 1; i <= n; i++)
		d[i] = t[i] = 0;
	Try(1, 0, 0);					// goi thu tuc Try de quy
	for (int i = 1; i <= n; i++)
		if (t[i]) cout << i << " ";		// ghi ket qua 
	return 0;
}
