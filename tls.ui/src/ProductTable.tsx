import Portrait from './Portrait';
import IncDecCounter from './IncDecCounter';
import { ProductView, compareProduct } from './types';
import clear from './assets/clear.svg';
import './ProductTable.css';
import { Skeleton } from '@mui/material';

type Props = {
  products: Map<string, ProductView>;
  isLoading: boolean;
  handleChange: (newProducts: Map<string, ProductView>) => void;
};

export default function ProductTable({
  products,
  isLoading,
  handleChange,
}: Props) {
  const handleQuantityChange = (productId: string, newQuantity: number) => {
    products.get(productId)!.quantity = newQuantity;
    // must pass in a new Map to reflect the change
    handleChange(new Map(products));
  };

  const handleClear = (productId: string) => {
    products.get(productId)!.quantity = 0;
    // must pass in a new Map to reflect the change
    handleChange(new Map(products));
  };

  const renderSkeletons = () =>
    [0, 1, 2, 3].map((number) => (
      <tr key={number}>
        <td className='Product-portrait'>
          <Skeleton variant='rectangular' height={44} />
        </td>
        <td className='Product-price'>
          <Skeleton variant='rectangular' height={18} />
        </td>
        <td>
          <Skeleton variant='rectangular' />
        </td>
        <td className='Product-total'>
          <Skeleton variant='rectangular' height={18} />
        </td>
        <td className='Product-delete'>
          <Skeleton variant='rectangular' height={18} />
        </td>
      </tr>
    ));

  return (
    <table className='Product-table'>
      <thead>
        <tr>
          <th></th>
          <th>Price</th>
          <th>QTY</th>
          <th>Total</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {isLoading
          ? renderSkeletons()
          : Array.from(products.values())
              .sort(compareProduct)
              .map((product) => (
                <tr key={product.id}>
                  <td className='Product-portrait'>
                    <Portrait
                      imgSrc={product.imageUrl}
                      imgAlt={`${product.size.name} ${product.name}`}
                      primaryText={product.name}
                      secondaryText={product.size.name}
                    />
                  </td>
                  <td className='Product-price'>{product.price.toFixed(2)}</td>
                  <td>
                    <IncDecCounter
                      num={product.quantity}
                      handleChange={(newQuantity) =>
                        handleQuantityChange(product.id, newQuantity)
                      }
                    />
                  </td>
                  <td className='Product-total'>
                    {(product.price * product.quantity).toFixed(2)}
                  </td>
                  <td className='Product-delete'>
                    <button title='Clear'>
                      <img
                        src={clear}
                        alt='Clear'
                        onClick={() => handleClear(product.id)}
                      />
                    </button>
                  </td>
                </tr>
              ))}
      </tbody>
    </table>
  );
}
