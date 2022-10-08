import './IncDecCounter.css';

type Props = {
  num: number;
  handleChange: (newNum: number) => void;
};

export default function IncDecCounter({ num, handleChange }: Props) {
  return (
    <div className='IncDecCounter'>
      <button type='button' onClick={() => num > 0 && handleChange(num - 1)}>
        −
      </button>
      <span>{num}</span>
      <button type='button' onClick={() => handleChange(num + 1)}>
        +
      </button>
    </div>
  );
}
