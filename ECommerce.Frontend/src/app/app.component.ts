import { Component, OnInit } from '@angular/core';
import { ProductService } from './service/product.service'
import { FormProductService } from './service/form-product.service'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Product } from './models/product.model';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'E-Comerce Frontend';
  products: Product[] = [];
  product: Product | undefined;
  searchForm!: FormGroup;
  
  constructor(private productService: ProductService,
    private formProductService: FormProductService) {
    this.searchForm = this.formProductService.newFormProduct(this.searchForm);
  }

  ngOnInit() {
    this.loadProducts();
  }

  onSubmit(){
     const productForm = this.searchForm.value;
     console.log('Formulario:', productForm);
     this.findProduct(productForm.id);

     if(this.product != null)
     {
      let employeeSelected = this.products.filter(emp => emp.id == this.product?.id);
      this.products = employeeSelected;
     }
  }

  private loadProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (data: Product[]) => {
        this.products = data;
      },
      error: (error) => {
        console.error('Error al obtener la lista de productos:', error);
      },
    });
  }

  private findProduct(id: string): void {
    this.productService.getOneProduct(id).subscribe({
      next: (data: Product) => {
        this.product = data;
      },
      error: (error) => {
        console.error('Error al obtener el producto:', error);
      },    
    });
  }
}
