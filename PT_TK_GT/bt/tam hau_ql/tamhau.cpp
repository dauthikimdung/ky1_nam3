#include <conio.h>
#include <stdio.h>
//x[i]=j : phan tu thu i tren cot j
//a[i] cot i da xet ?
//b c la duong cheo
int x[9], a[9];
int b[16], c[16];
int thu(int i);
int init();
int printkq();
int main()
{
	init();
	thu(1);
	return 0;
	
}
//khoi tao
int init()
{
	for (int i = 1; i <= 8; i++)
	{
		x[i] = 0; // phan tu thu i chua dc 
		a[i] = 0; // ko co quan nao o cot i
	}
	for (int i = 1; i <= 15; i++)
	{
		b[i] = 0;// ko co quan nao o duong cheo nguoc 
		c[i] = 0;// ko co quan nao o duong cheo thuan dat tren cot
		
	}
	return 0;
}

int printkq()
{
	for (int i = 1; i <= 8; i++)
		printf("%d-", x[i]);// in vi tri con hau thu i tai cot j
			printf("\n");
	return 0;
}

// truyen con hau thu i se tuong ung voi hang thu i
int thu(int i)
{
	for (int j = 1; j <= 8; j++)// duyet cac cot
	{
		if (a[j]==0 && b[i + j - 1]==0 && c[i - j + 8]==0)// cac cot va hang cheo van co the duoc chon
		{
			x[i] = j;//p tu thu i dat o cot j
			a[j] = 1; // cot j da xet
			b[i + j - 1] = 1;// duong cheo nguoc ko con nua
			c[i - j + 8] = 1;// duong cheo thuan ko con nua
			if (i < 8)
				thu(i + 1);// chua het thi duyet con hau tiep theo
			else
			{
				printkq();// in kq
			}
			// tro lai trang thai truoc
			a[j] = 0;
			b[i + j - 1] = 0;
			c[i - j + 8] = 0;
		}
	}
	return 0;
}

