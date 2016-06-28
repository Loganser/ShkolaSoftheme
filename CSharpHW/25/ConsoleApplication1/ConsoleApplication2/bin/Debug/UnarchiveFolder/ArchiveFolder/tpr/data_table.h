
class Data_table
{
private:
	string::size_type sz;
	int n,m,p;
	vector <vector <double> > x;
	vector <vector <string> > am;

	string dtos (double v)
	{
		string r1="", r2="", res="";
		int int_v = v;
		v-=int_v;
		if (int_v==0) {r1+=48;}
		while (int_v>0)
		{
			r1+=(int_v%10+48);
			int_v/=10;
		}
		v*=10;
		r2+=(int(v)+48);
		v-=int(v);
		v*=10;
		r2+=(int(v)+48);
		
		for (int i=r1.size()-1; i>=0; i--) res+=r1[i];
		res+=".";
		res+=r2;
		return res;
	}

	pair <double, double> MNK (vector <double> x, vector <double> y)
	{
		int a1=0, b1=0, c1=0;
		
		for (int i=0; i<y.size(); i++) a1+=y[i]+x[i]*y[i];
		for (int i=0; i<y.size(); i++) b1+=y[i];
		b1*=2;
		for (int i=0; i<x.size(); i++) c1+=x[i];
		c1*=2;

		int a2=0, b2=0, c2=0;
		for (int i=0; i<y.size(); i++) a2+=x[i]+x[i]*y[i];
		for (int i=0; i<y.size(); i++) b2+=y[i]+x[i]*y[i]+y[i]*y[i];
		b2*=2;
		for (int i=0; i<x.size(); i++) c2+=x[i]+x[i]*x[i];
		c2*=2;
		
		double  bet2 = (c2*(-c1-b1)*a1+b1+b2) , bet1 = (c1*(-c2-b2)*a1+a1+a2) ;
		
		return (make_pair(bet1,bet2));
	}

public:
	Data_table::Data_table(vector <vector <string> >  na, int nn, int nm, int np)
	{
		
			n=nn;
			n=nm;
			p=np;
			x.resize(p);
			am.resize(p);
			for (int i=0; i<p; i++)
				for (int j=0; j<n+m; j++)
				{
					am[i].push_back(na[i][j]);
				}

			for (int i=0; i<p; i++)
				for (int j=0; j<n+m; j++)
				{
					if (na[i][j]!="*") x[i].push_back(stod (na[i][j],&sz)); else x[i].push_back(0);
				}
			
	}
	
	Data_table::~Data_table()
	{
		x.clear();
	}
	
	void Read ()
	{
		string::size_type sz;
		ifstream in("input.txt");
		in>> n >> m >>p;
		x.resize(p);
		am.resize(p);
		string str;
		
		for (int i=0; i<p; i++)
				for (int j=0; j<n+m; j++)
				{
					in>> str;
					
					am[i].push_back(str);
					if (str!="*") x[i].push_back(stod (str,&sz)+0.002); else x[i].push_back(0);
				}
	}
	
	
	void Write ()
	{
		ofstream out("output.txt");
		for (int i=0; i<n; i++) 
		{
			out << "X" << i+1 << "     ";
		}
		
		for (int i=0; i<m; i++) 
		{
			out << "Y" << i+1 << "     ";
		}

		out << endl;

		for (int i=0; i<p; i++){
			
			for (int j=0; j<n+m; j++)
			{
				string str_res;
				if (am[i][j]=="*")
					str_res = am[i][j]; else
				    str_res =  dtos(x[i][j]);
				out<< str_res;
				int k=0;
				while (k+str_res.length()<7) {k++; out << " ";}
			}
			out<< endl;
		}
	}
	

	void Middle_val_method ()
	{
		vector <double> y;
		vector <int> q;
		y.resize(n);
		for (int i=0; i<n; i++) q.push_back(0);

		for (int i=0; i<p; i++)
			for (int j=0; j<n; j++)
				if (am[i][j]!="*")
				{
					y[j]+=x[i][j];
					q[j]++;
				}
		for (int i=0; i<n; i++) y[i]/=q[i];

		for (int i=0; i<p; i++) 
			for (int j=0; j<n; j++) 
				if (am[i][j]=="*") 
				{
					x[i][j]=y[j]; 
					am[i][j]= dtos (x[i][j]);
				}
	}

	void Delete_notcomplect_rows ()
	{
		vector <bool> b;
		b.resize(p);
		for (int i=0; i<p; i++) b[i] = 0;

		for (int i=0; i<p; i++)
			for (int j=0; j<n; j++)
			{
				if (am[i][j]=="*") b[i] = 1;
			}
		vector <vector <double> > new_x;
		vector <vector <string> > new_am;

		for (int i=0; i<p; i++)
			if (b[i])
			{
				new_x.push_back(x[i]);
				new_am.push_back(am[i]);
			}
			am=new_am;
			x=new_x;
			new_am.clear();
			new_x.clear();
	}


	

	void Resampling_1 ()
	{
		vector <pair <double, double> > regr_k;
		vector <bool> b;
		b.resize(p);
		for (int i=0; i<p; i++) b[i] = 0;

		for (int i=0; i<p; i++)
			for (int j=0; j<n; j++)
			{
				if (am[i][j]=="*") b[i] = 1;
			}


		for (int i=0; i<p; i++)
		{
			vector <double> y;
			for (int i=0; i<n; i++) y.push_back(x[0][m]);
			if (!b[i]) 
			{
				regr_k.push_back( MNK (x[i],y));
			}
		}

		vector <double> y;
		y.resize(n);

		for (int i=0; i<p; i++)
			for (int j=0; j<n; j++)
				if (am[i][j]!="*")
				{
					y[j]+=x[i][j];
					
				}
		for (int i=0; i<n; i++) y[i]/=p;

		for (int i=0; i<p; i++) 
			for (int j=0; j<n; j++) 
				if (am[i][j]=="*") 
				{
					x[i][j]=y[j]; 
					am[i][j]= dtos (x[i][j]);
				}

	
	}

};

