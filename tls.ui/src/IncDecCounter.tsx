import './IncDecCounter.css';

type Props = {
  num: number;
  handleChange: (newNum: number) => void;
};

export default function IncDecCounter(props: Props) {
  const num = props.num;

  return (
    <div className='IncDecCounter'>
      <button
        type='button'
        onClick={() => num > 0 && props.handleChange(num - 1)}
      >
        −
      </button>
      <span>{num}</span>
      <button type='button' onClick={() => props.handleChange(num + 1)}>
        +
      </button>
    </div>
  );
}
