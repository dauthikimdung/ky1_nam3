#include <iostream>
#include <fstream>
using namespace std;

#define MAX 100
struct item
{
    int w;//trong luong
    int v;//gia tri
    int num = 0; // 0 or 1
};
int num = 0; // So cach
int best = 0; // Cach tot nhat
int W;    // trong luong toi da cua tui                                  
 int   N; // so do vat                                       
item Items[MAX + 1];  // mang chua do vat                       
int d[MAX + 1] = {0};                         
float curr_val = 0,        // gia tri hien tai                   
    curr_weight = 0;           // trong luong hien tai               
float maxVal = 0;// gia  tri cua tui la lon nhat
float totalWeight = 0;// trong luong cua tui la lon nhat
float total = 0; //tong so do vat

void Input()
{
    ifstream infile;
    infile.open("input1.txt");
    infile >> W >> N;
    cout << "n=" << N << " w=" << W << "\n";
    for (int i = 1; i <= N; i++)
    {
        infile >> Items[i].w >> Items[i].v;
        cout << "#" << i << ": " << Items[i].w << " " << Items[i].v << "\n";
    }
    infile.close();
}

void test()// chon cach lay toi uu nhat
{	
    num++;
    if (curr_val > maxVal)// MaxVal khoi tao = 0
    {
    	best = num;
        maxVal = curr_val;
        totalWeight = curr_weight;
        total = 0;
        for (int i = 1; i <= N; i++)
        {
            Items[i].num = d[i];//mang d[k] luu so luong vat k dc chon 
            total += d[i];// tong so luong tang len mot luong bang d[i]
        }
    }
	cout << "Cach "<< num <<endl;
	cout << "~ Chon cac do vat: ";
	for(int z = 1; z <= N; z++){
		if(d[z]) cout << z <<" ";
	}
	cout << endl;
	cout << "~ "<< "Gia tri: " << curr_val << " Khoi luong: " << curr_weight <<endl;
}

void Try(int k)// xet do vat thu k
{
    for (int i = 0; i <= 1; i++)//xet do vat thu k co the chon =0 hoac 1
    {
        if (curr_weight + i * Items[k].w <= W)// neu khoi luong hien tai + khoi luong cua vat thu k * i < Khoi luong toi da cua tui ( i=1 || i=0   ==> lay vat k hoac khong lay k)
        {
            curr_weight += i * Items[k].w;// cap nhat lai khoi luong hien tai khi lay vat k
            curr_val += i * Items[k].v;// cap nhat lai gia tri hien tai khi lay vat k
            d[k] = i;// gan so luong vat k lay = i

            if ((k == N) && (curr_weight <= W))
            {
                test();
            }
            else
            {
                Try(k + 1);
            }

            curr_weight -= i * Items[k].w;// tra lai gia tri
            curr_val -= i * Items[k].v;
            d[k] = 0;
        }
    }
}

void PrintResult()
{
	cout << "\nChon cach: " << best <<endl;
    cout << "\nCac vat da lay: ";
    for (int i = 1; i <= N; i++)
    {
        if (Items[i].num)
        {
            cout << i << " ";
        }
    }
    cout << "\nTong so vat da lay: " << total;
    cout << "\nGia tri lon nhat co the lay: " << maxVal;
    cout << "\nKhoi luong da su dung: " << totalWeight << endl;
}

int main()
{
    Input();
    Try(1);
    PrintResult();
}
