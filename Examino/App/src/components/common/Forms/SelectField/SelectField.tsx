import { Controller, Control } from "react-hook-form";
import Select, { StylesConfig } from "react-select";
import { SelectFieldOptionViewModel } from "../../../../models/Forms/SelectFieldOptionViewModel";
import styles from "./SelectField.module.scss";

interface Props {
  control: Control<any>;
  name: string;
  errors: any;
  label: string;
  options: SelectFieldOptionViewModel[];
  placeholder?: string;
  disabled?: boolean;
}

const customStyles: StylesConfig<SelectFieldOptionViewModel, false> = {
  control: (provided, { isDisabled }) => ({
    ...provided,
    height: "40",
    minHeight: "40",
    borderColor: "#ccc",
    boxShadow: "none",
    "&:hover": {
      borderColor: "#ccc",
    },
    color: isDisabled ? "#545454" : "inherit",
  }),
  valueContainer: (provided) => ({
    ...provided,
    padding: "0 0.75rem",
  }),
  singleValue: (provided) => ({
    ...provided,
    margin: "0",
    color: "inherit",
  }),
  input: (provided) => ({
    ...provided,
    margin: "0",
    padding: "0",
  }),
  indicatorSeparator: () => ({
    display: "none",
  }),
};

const SelectField = ({
  control,
  name,
  errors,
  label,
  options,
  placeholder,
  disabled,
}: Props) => {
  return (
    <div className={styles.wrapper}>
      <label htmlFor={name}>{label}</label>
      <Controller
        name={name}
        control={control}
        render={({ field: { value, onChange } }) => {
          return (
            <Select
              options={options}
              placeholder={placeholder ? placeholder : ""}
              value={options.filter((option) => value?.includes(option.value))}
              onChange={(option) => onChange(option?.value)}
              styles={customStyles}
              isDisabled={disabled}
            />
          );
        }}
      />
      {errors[name] && (
        <div className={styles.error}>{errors[name].message}</div>
      )}
    </div>
  );
};

export default SelectField;
