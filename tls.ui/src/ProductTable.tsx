import Portrait from './Portrait';
import IncDecCounter from './IncDecCounter';
import { ProductView, compareProduct } from './types';
import lemon from './assets/lemon.svg';
import clear from './assets/clear.svg';
import './ProductTable.css';

type Props = {
  products: Map<string, ProductView>;
  handleChange?: (newProducts: Map<string, ProductView>) => void;
};

export default function ProductTable(props: Props) {
  const products = props.products;

  const handleQuantityChange = (productId: string, newQuantity: number) => {
    products.get(productId)!.quantity = newQuantity;
    handleChange(new Map(products));
  };

  const handleClear = (productId: string) => {
    products.get(productId)!.quantity = 0;
    handleChange(new Map(products));
  };

  const handleChange = (newProducts: Map<string, ProductView>) => {
    // must pass in a new Map to reflect the change
    if (props.handleChange) {
      props.handleChange(new Map(products));
    }
  };

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
        {Array.from(products.values())
          .sort(compareProduct)
          .map((product) => (
            <tr key={product.id}>
              <td>
                <Portrait
                  imgSrc={lemon}
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
              <td>
                <button className='Product-delete' title='Clear'>
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
