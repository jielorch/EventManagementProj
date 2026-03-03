import { AfterViewInit, Component, DestroyRef, inject, OnInit, signal } from '@angular/core';
import { ProductRepository } from '../../../core/repositories/product.repository';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { Product } from '../../../core/models/product';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home implements OnInit, AfterViewInit{


  productRepository = inject(ProductRepository);
  destroyRef = inject(DestroyRef);

  products = signal<Product[]>([]);

  ngOnInit(): void {
    this.productRepository.getProducts().pipe(
      takeUntilDestroyed(this.destroyRef)
    ).subscribe({
      next:(res) => {
        if(res){
          this.products.set(res);
        }
      },
      error:(err) => {
        console.log('Error:', err);
      }
    });
  }

  ngAfterViewInit(): void {
     
  }

  loadMore(){
    this.productRepository.loadMore().pipe(
      takeUntilDestroyed(this.destroyRef)
    ).subscribe({
      next:(res) => {
        if(res){
          this.products.update(current => [...current, ...res]);
        }
      },
      error:(err) => {
        console.log('Error:', err);
      }
    });
  }

}
